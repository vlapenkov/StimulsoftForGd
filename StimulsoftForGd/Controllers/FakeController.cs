using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edit_Report_in_the_Designer.Controllers
{
    /// <summary>
    /// Класс который эмулирует работу endpoint
    /// </summary>
    public class FakeController :Controller
{
       
       
            public async Task<IEnumerable<AccrualsPaymentsNodeDto>> Index(DateTime? sDate, int? id)
            {

          
            var path = "Reports/Data/DataByPeriod.json";
            if (sDate.HasValue && sDate.Value.Year==2019)  path = "Reports/Data/DataByPeriod2.json";
            
                

            IEnumerable<AccrualsPaymentsNodeDto> data;
                var pathToFile = StiNetCoreHelper.MapPath(this, path);
                var json = System.IO.File.ReadAllText(path);

                data = JsonConvert.DeserializeObject<IEnumerable<AccrualsPaymentsNodeDto>>(json);
                return data;
            }

       
    }
}
