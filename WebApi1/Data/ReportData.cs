using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Data
{
    public class ReportData
    {
        //[Key]
       // [StringLength(128)]
        public string Id { get; set; }

       // [ForeignKey("ReportSettings")] - заменил в fluentapi
        public string ReportSettingsId { get; set; }

        public ReportSettings ReportSettings { get; set; }

        public byte[] FileBody { get; set; }

        /// <summary>
        /// Тип файла (xml/json)
        /// </summary>
      //  [StringLength(128)]
        public string FileType { get; set; } = "application/xml";
    }
}
