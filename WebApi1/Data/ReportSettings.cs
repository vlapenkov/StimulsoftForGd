using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi1.Data;

namespace WebApi1
{
    /// <summary>
    /// Контейнер для данных из mrt-файла
    /// </summary>
    public class ReportSettings
    {
       // [Key]
       // [StringLength(128)]
        public string Id { get; set; }

        public byte[] FileBody { get; set; }

        public ICollection<ReportData> Reports { get; set; }
    }
}