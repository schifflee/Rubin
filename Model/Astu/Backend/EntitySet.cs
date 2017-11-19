﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Common;
using System.Data;

namespace Model.Astu
{
    /// <summary>
    /// Предоставляет набор всех сущностей указанного типа, которые могут быть загружены из базы данных
    /// </summary>
    /// <typeparam name="TEntity">Тип загружаемой сущности</typeparam>
    public class EntitySet<TEntity>: List<TEntity>, IEntitySet where TEntity: Entity
    {
        string _sqlOption;

        public event EntityRemovingHandler OnEntityRemoving;
        
        /// <summary>
        /// Инициализирует коллекцию и загружает ее из БД
        /// </summary>
        /// <param name="sqlOption">Опция будет дописана в финальный запрос "SELECT {Fields} FROM {TableName}"</param>
        public EntitySet(string sqlOption = null)
        {
            _sqlOption = sqlOption;
            Reset();            
        }        

        /// <summary>
        /// Очищает текущую коллекцию и заново подгружает все элементы из БД
        /// </summary>
        public void Reset()
        {
            Clear();
            var dbConnection = Astu.DbConnection;
            var type = typeof(TEntity);

            // Получаем коллекцию загружаемых полей объекта
            var fields = type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).Count() > 0);

            // Составляем строку запроса
            var sb = new StringBuilder();
            sb.Append("SELECT ");
            foreach (var f in fields)
            {
                if (f.PropertyType == typeof(string))
                {
                    sb.AppendFormat("TRIM({0})",
                        (f.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).First() as DbFieldInfoAttribute).Name);
                }
                else
                {
                    sb.Append((f.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).First() as DbFieldInfoAttribute).Name);
                }
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);

            var tableName = (type.GetCustomAttributes(typeof(TableNameAttribute), true).First() as TableNameAttribute).Value;
            sb.AppendFormat(" FROM {0}", tableName);
            // докидывем условие, если оно есть
            if (!string.IsNullOrWhiteSpace(_sqlOption))
            {
                sb.AppendFormat(" {0}", _sqlOption);
            }

            // Создаем SQL команду для выполнения запроса и загрузки данных
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sb.ToString();
            using (var reader = dbCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // создаем объект типа
                        var ci = type.GetConstructor(new Type[] { });
                        TEntity record = (TEntity)ci.Invoke(null);
                        int i = 0;
                        foreach (var f in fields)
                        {
                            object value = reader.GetValue(i);

                            // КОСТЫЛЬ: проверка типов
                            if (value.GetType() == typeof(DBNull))
                            {
                                value = null;
                            }
                            else
                            {
                                if (value.GetType() == typeof(decimal))
                                {
                                    if (f.PropertyType == typeof(bool))
                                    {
                                        if ((value as decimal?) > 0)
                                        {
                                            value = (bool)true;
                                        }
                                        else
                                        {
                                            value = (bool)false;
                                        }
                                    }
                                    else
                                    {
                                        if (f.PropertyType == typeof(int) || f.PropertyType == typeof(int?))
                                        {
                                            value = Convert.ToInt32(value);
                                        }
                                    }
                                }
                            }

                            f.SetValue(record, value, null);
                            i++;
                        }

                        (record as Entity).EntityState = EntityState.Default;
                        base.Add((TEntity)record);
                    }
                }
            }
        }

        /// <summary>
        /// Удаляет элемент из коллекции. Данный элемент будет удален из БД при вызове DatabaseModel.Save().
        /// </summary>
        /// <param name="item">Удаляемый элемент</param>
        public new void Remove(TEntity item)
        {
            base.Remove(item);
            item.EntityState = EntityState.Deleted;
            OnEntityRemoving(item);
        }

        /// <summary>
        /// Возвращает тип элемента коллекции
        /// </summary>
        /// <returns></returns>
        public Type GetItemType()
        {
            return typeof(TEntity);
        }

        public void InitializeNavigatedCollections()
        {
            foreach (var item in this)
            {
                item.InitializeNavigatedCollections();
            }
        }
    }
}
