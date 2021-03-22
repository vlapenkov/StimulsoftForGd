using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Shared.Interfaces;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edit_Report_in_the_Designer.Controllers
{
    /// <summary>
    /// Класс который эмулирует работу endpoint
    /// </summary>
    public class FakeController :Controller
{

        IReportDataService _reportDataService;

        public FakeController(IReportDataService reportDataService)
        {
            _reportDataService = reportDataService;
        }

        public async Task<IEnumerable<AccrualsPaymentsNodeDto>> Index(DateTime? sDate, int? id)
            {

          //  if(Request.Headers["User-Agent"][0].Contains("Chrome"))
           //     throw new NotImplementedException();

            var path = "Reports/Data/DataByPeriod.json";
            if (sDate.HasValue && sDate.Value.Year==2019)  path = "Reports/Data/DataByPeriod2.json";
            
                

            IEnumerable<AccrualsPaymentsNodeDto> data;
                var pathToFile = StiNetCoreHelper.MapPath(this, path);
                var json = System.IO.File.ReadAllText(path);

                data = JsonConvert.DeserializeObject<IEnumerable<AccrualsPaymentsNodeDto>>(json);
                return data;
            }

        public IActionResult Xml()
        {

            var xmlFile=Request.Query["xmlFile"].ToString();
            var path =  StiNetCoreHelper.MapPath(this, "Reports/Data/"+ xmlFile); 
            var xml = System.IO.File.ReadAllText(path);

            return Ok(xml);
        }

        /// <summary>
        /// Для тестов с xml от Михаила xmlFile=data2
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Xml2()
        {
        //http://localhost:5000/Fake/Xml2
            var xmlFile = Request.Query["xmlFile"].ToString();

          var bytesData=  await _reportDataService.GetData(xmlFile);
            // string stringData = Convert.ToBase64String(byteData);
            string stringData = Encoding.UTF8.GetString(bytesData, 0, bytesData.Length);

            return Ok(stringData);
        }


    }
}
