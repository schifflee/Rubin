﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Город
    /// </summary>
    public class Town
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Префикс
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Код объекта в БД ФИАС
        /// </summary>
        public string FiasCode { get; set; }

        /// <summary>
        /// Код объекта в БД КЛАДР
        /// </summary>
        public string KladrCode { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public int? RegionId { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public Region Region { get; set; }
    }
}
