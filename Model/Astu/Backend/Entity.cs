﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.Astu
{
	/// <summary>
	/// Предоставляет базовый функционал для сущности
	/// </summary> 
	public abstract class Entity: PropertyChangedBase, ICloneable
	{
        public Entity()
        {
            PropertyChanged += OnPropertyChanged;
        }

        #region Служебные поля

        EntityState _entityState = EntityState.New;

        [NoMagic]
        /// <summary>
        /// Физическое состояние сущности
        /// </summary>
        public EntityState EntityState
        {
            get
            {
                return _entityState;
            }
            internal set
            {
                _entityState = value;
            }
        }
		
        /// <summary>
        /// Возвращает имя таблицы в БД, соответствующей данной сущности
        /// </summary>
        string TableName
        {
            get
            {
                var attributeList = this.GetType().GetCustomAttributes(typeof(TableNameAttribute), true);
                if (attributeList.Count() == 0)
                {
                    throw new Exception();
                }
                var p = attributeList.First() as TableNameAttribute;
                return p.Value;
            }
        }

        /// <summary>
        /// Имя поля первичного ключа
        /// </summary>
        string PrimaryFieldName
        {
            get
            {
                var props = GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0)
                    {
                        var fieldName = prop.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).FirstOrDefault() as DbFieldInfoAttribute;
                        if (fieldName == null)
                        {
                            throw new ArgumentNullException(string.Format("Для свойства {0} не указан сопоставляемый тип", prop.Name));
                        }
                        return fieldName.Name;
                    }
                }
                throw new InvalidOperationException("Для таблицы не указано поле первичного ключа");
            }
        }
        
        #endregion

        #region Sql методы

        internal string GetSaveQuery()
        {
            string str = string.Empty;
            switch (EntityState)
            {
                case EntityState.Default:
                    break;
                case EntityState.New:
                    str = InsertQuery();
                    break;
                case EntityState.Changed:
                    str = UpdateQuery();
                    break;
                case EntityState.Deleted:
                    str = DeleteQuery();
                    break;
                default:
                    throw new InvalidEnumArgumentException("Unknown entity state");
            }

            //Encoding utf8 = Encoding.UTF8;
            //Encoding cp1251 = Encoding.GetEncoding("Windows-1251");
            //byte[] utf8Bytes, cp1251Bytes;
            //utf8Bytes = utf8.GetBytes(str);
            //cp1251Bytes = Encoding.Convert(utf8, cp1251, utf8Bytes);
            //string finalQuery = cp1251.GetString(cp1251Bytes);
            return str;
        }
        
        string DeleteQuery()
        {
            return string.Format("DELETE FROM {0} WHERE {1}={2};", 
                TableName, PrimaryFieldName, ConvertObjectToExpression(GetDatabaseFieldType("Id"), GetPropertyInfo("Id").GetValue(this, null)));
        }

        string InsertQuery()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("INSERT INTO {0} ", TableName);
            sb.Append("(");

            // Получаем набор свойств с аттрибутом FieldName
            var props = this.GetType().GetProperties().Where(pi => pi.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).Count() > 0);
            foreach (var prop in props)
            {
                var fieldName = prop.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).First() as DbFieldInfoAttribute;
                sb.AppendFormat("{0},", fieldName.Name);
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") VALUES (");

            foreach (var prop in props)
            {
                sb.AppendFormat("{0},",ConvertObjectToExpression(GetDatabaseFieldType(prop.Name), GetPropertyInfo(prop.Name).GetValue(this, null)));
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(");");

            return sb.ToString();
        }

        string UpdateQuery()
        {
            var primaryKey = this.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0).FirstOrDefault();
            if (primaryKey == null)
            {
                throw new InvalidOperationException("Не указано поле первичного ключа");
            }

            var sb = new StringBuilder();
            sb.AppendFormat("UPDATE {0} ", TableName);
            sb.Append("SET ");
            // Получаем набор свойств с аттрибутом FieldName 
            var props = this.GetType().GetProperties().Where(pi => 
            (pi.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).Count() > 0 && 
            pi.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() == 0));

            foreach (var prop in props)
            {
                var fieldName = prop.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).First() as DbFieldInfoAttribute;
                sb.AppendFormat("{0}={1},", 
                    fieldName.Name, 
                    ConvertObjectToExpression(GetDatabaseFieldType(prop.Name), 
                    GetPropertyInfo(prop.Name).GetValue(this, null)));
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" WHERE {0}={1}",
                PrimaryFieldName, 
                ConvertObjectToExpression(GetDatabaseFieldType(primaryKey.Name), GetPropertyInfo(primaryKey.Name).GetValue(this, null)));
            return sb.ToString();
        }
        
        #endregion

        #region Служебные и вспомогательные методы

        /// <summary>
        /// Возвращает строковое представление объекта в формате SQL выражения
        /// </summary>
        /// <param name="databaseFieldType">Тип поля объекта в БД</param>
        /// <param name="value">Сам объект</param>
        /// <returns></returns>
        string ConvertObjectToExpression(DbFieldType databaseFieldType, object value)
        {
            if (value == null)
            {
                return "NULL";
            }
            switch (databaseFieldType)
            {
                case DbFieldType.String:
                    return string.Format(@"'{0}'", value.ToString());
                case DbFieldType.Integer:
                    return value.ToString();
                case DbFieldType.Double:
                    return value.ToString();
                case DbFieldType.DateTime:
                    return string.Format(@"TO_DATE('{0}', 'YYYYMMDD')", ((DateTime)value).ToString("yyyyMMdd"));
                case DbFieldType.Boolean:
                    return ((bool)value) == true ? "1" : "0";
                default:
                    throw new InvalidOperationException("Non-registered field type.");
            }
        }

        /// <summary>
        /// Возвращает сопоставляемый тип поля в таблице базы данных для указанного свойства
        /// </summary>
        /// <param name="propertyName">Имя заданного свойства</param>
        /// <returns></returns>
        DbFieldType GetDatabaseFieldType(string propertyName)
        {
            var p = this.GetType().GetProperty(propertyName).GetCustomAttributes(typeof(DbFieldInfoAttribute), true).FirstOrDefault() as DbFieldInfoAttribute;
            if (p == null)
            {
                throw new Exception(string.Format("Для свойства {0} не указано сопоставляемое поле.", propertyName));
            }
            return p.Type;
        }

        PropertyInfo GetPropertyInfo(string propertyName)
        {
            return this.GetType().GetProperty(propertyName);
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_entityState == EntityState.Default)
            {
                _entityState = EntityState.Changed;
            }
        }

        /// <summary>
        /// Возвращает автономную копию текущей сущности
        /// </summary>
        public object Clone()
        {
            // Создаем новый объект текущего типа
            var type = GetType();
            var obj = type.GetConstructor(new Type[] { }).Invoke(null);

            // Пробегаем по свойствам текущего типа, соответсвующим полям в таблице БД
            Dictionary<string, object> dbProperties = new Dictionary<string, object>();
            var fields = type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).Count() > 0);
            foreach (var f in fields)
            {
                dbProperties.Add(f.Name, f.GetValue(this, null));
            }

            // По каждому получаем значение и пишем его в соответствующее свойство нового объекта
            foreach (var item in dbProperties)
            {
                type.GetProperty(item.Key).SetValue(obj, item.Value, null);
            }

            // Устанавливаем значение EntityState в новое
            (obj as Entity).EntityState = EntityState.New;

            return obj;
        }

        /// <summary>
        /// Возвращает true, если связанные с БД свойства объекта равны аналогичным свойствам obj
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // если разные типы, то сразу неравные
            if (obj.GetType() != GetType())
            {
                return false;
            }

            // Пробегаем по свойствам текущего типа, соответсвующим полям в таблице БД
            var type = GetType();
            bool result = true;

            var fields = type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(DbFieldInfoAttribute), true).Count() > 0);
            foreach (var f in fields)
            {
                var objValue = type.GetProperty(f.Name).GetValue(obj, null);
                var selfValue = type.GetProperty(f.Name).GetValue(this, null);
                if (!objValue.Equals(selfValue))
                {
                    result = false;
                }
            }
            return result;
        }

        #endregion
    }	
}