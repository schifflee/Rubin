﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Уровень образования (СПО, ВО)
    /// </summary>
    public class EducationLevel
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
        /// Аббревиатура
        /// </summary>
        public string ShortName { get; set; }
    }
}
