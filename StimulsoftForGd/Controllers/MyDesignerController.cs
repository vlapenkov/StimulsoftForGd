
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class MyDesignerController : Controller
    {
        public async Task<IActionResult> Index()
        {

            return View();
        }




        public async Task<IActionResult> GetReport()
        {

            StiReport report = new StiReport();


            report.Load(StiNetCoreHelper.MapPath(this, "Reports/payments-preset.mrt"));
                        
              
            return StiNetCoreDesigner.GetReportResult(this, report);

        }


        public IActionResult PreviewReport()
        {

            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);
           

            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

       

        public async Task<IActionResult> DesignerEvent()
        {

            var requestParams = StiNetCoreDesigner.GetRequestParams(this);

          
            

            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}
