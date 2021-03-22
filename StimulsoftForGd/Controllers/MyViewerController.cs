using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Models;
using Newtonsoft.Json;
using Shared.Interfaces;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class MyViewerController :Controller
{
        IReportSettingsService _settingsService;

        public MyViewerController(IReportSettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            StiReport report = new StiReport();

            string mrt = HttpContext.Request.Query["settingsId"];

            if (mrt != null)
            {
                report.Load(StiNetCoreHelper.MapPath(this, "Reports/" + mrt));
            }

            //   для каждой переменной находим  параметр из query string

            foreach ( StiVariable variable in report.Dictionary.Variables)
            {                              
              string queryParameterValue = HttpContext.Request.Query[variable.Name];
               if(queryParameterValue!=null)
                    report.Dictionary.Variables[variable.Name].Value = queryParameterValue;
            }
                                


            return StiNetCoreViewer.GetReportResult(this, report);
            }

            //public async Task<IActionResult> GetReport()
            //{
            //   // var text = await _settingsService.GetSettings("app4");
            //    StiReport report = new StiReport();

            //    // получаем настройки
            //    string mrt = HttpContext.Request.Query["settingsId"];

            //    if (mrt != null)
            //    {
            //        var settings = await _settingsService.GetSettings(mrt);

            //        report.Load(settings);
            //    }

            //    // получаем данные
            //    string xmlFile = HttpContext.Request.Query["dataId"];

            //    report.Dictionary.Variables["xmlFile"].Value = xmlFile; // "XMLFile2.xml";

            //    // http://localhost:5000/myviewer?settingsId=app4&dataId=newsrt555.xml
            //    //// http://localhost:5000/myviewer?settingsId=app4&dataId=data2

            //    return StiNetCoreViewer.GetReportResult(this, report);
            //}

            public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }


       
    }
}
