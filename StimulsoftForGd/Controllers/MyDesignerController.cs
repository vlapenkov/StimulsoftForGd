
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Shared;
using Shared.Interfaces;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class MyDesignerController : Controller
    {

        IReportSettingsService _settingsService;

        public MyDesignerController(IReportSettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }


        

        public async Task<IActionResult> GetReport()
        {

            //byte[] result1=  System.IO.File.ReadAllBytes(StiNetCoreHelper.MapPath(this, "Reports/data/newsrt555.xml"));
            //string base64Str = Convert.ToBase64String(result1);
            


           StiReport report = new StiReport();

          //  var id = HttpContext.Request.Query["settings"];

          //  //var result = await GetURLContentsAsync("http://localhost:5100/api/settings/getsettings?hash=app3");
          //  var text= await _settingsService.GetSettings("app4");
            

           // report.Load( "C:\\app1\\app1\\settings2.xml");
          //  //  report.Load(StiNetCoreHelper.MapPath(this, "Reports/Report_fromXml.mrt"));
          //  try
          //  {
          //      report.Load(result);
          //    //  report.Load(StiNetCoreHelper.MapPath(this, "Reports/app1.mrt"));
          //  }
          //  catch (Exception e)

          //  {
          //      Console.WriteLine(e);
          //  }

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

        public ActionResult SaveReportAs(string fileName)
        {

            StiReport report = StiNetCoreDesigner.GetReportObject(this);

            var requestParams = StiNetCoreDesigner.GetRequestParams(this);

            var reportName = requestParams.Designer.FileName;
            
            string settingsText = report.SaveToString();

            System.IO.File.WriteAllText("C:\\app1\\app1\\settings1.xml", settingsText);
            var newsettingsText = new SettingsTransformer().Transform(settingsText);
            // Completion of the report saving with message dialog box
            System.IO.File.WriteAllText("C:\\app1\\app1\\settings2.xml", newsettingsText);

            return StiNetCoreDesigner.SaveReportResult(this, "Some message after saving");
        }



    }
}
