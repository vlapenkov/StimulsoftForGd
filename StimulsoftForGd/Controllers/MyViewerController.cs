using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

using Stimulsoft.Report;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
           


            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/payments-preset.mrt"));
           

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }


       
    }
}
