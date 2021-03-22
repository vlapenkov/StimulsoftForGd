using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

using Newtonsoft.Json;

using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Web;

namespace Edit_Report_in_the_Designer.Controllers
{
    [AllowAnonymous]
    public class MyViewer1Controller :Controller
{
     public MyViewer1Controller()
        {
            StiOptions.Engine.ForceInterpretationMode = true;
        }
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult Interaction()
        {
            var report = StiNetCoreViewer.GetReportObject(this);            
          //  report.Render(false);
            report.CookieContainer = GetCookieContainer();
            return StiNetCoreViewer.InteractionResult(this, report);
        }

        public CookieContainer GetCookieContainer()
        {
            var cookieContainer = new CookieContainer();
            foreach (string key in HttpContext.Request.Cookies.Keys)
            {
                var value = HttpContext.Request.Cookies[key];
                if (!string.IsNullOrEmpty(value))
                {
                    var cookie = new Cookie()
                    {
                        Name = key,
                        Value = HttpUtility.UrlEncode(value),
                        Domain = "localhost",//HttpContext.Request.Host.Value,
                        Path = "/",
                        Expires = DateTime.Now.AddYears(1)
                    };
                    cookieContainer.Add(cookie);
                }
            }

            var testCookie = new Cookie()
            {
                Name = "Test",
                Value = HttpUtility.UrlEncode("123"),
                Domain = "localhost",//HttpContext.Request.Host.Value,
                Path = "/",
                Expires = DateTime.Now.AddYears(1)
            };
            cookieContainer.Add(testCookie);

            if (cookieContainer.Count > 0) return cookieContainer;

            return null;
        }


        public IActionResult GetReport()
        {
            StiReport report = new StiReport();
            

            report.Load(StiNetCoreHelper.MapPath(this, "Reports/payments-preset.mrt"));
           //  report.Render(false);
            report.CookieContainer = GetCookieContainer();

            return StiNetCoreViewer.GetReportResult(this, report);
        }
        //public IActionResult GetReport()
        //{
        //    StiReport report = new StiReport();
        //    report.CookieContainer = GetCookieContainer();

        //    string mrt = HttpContext.Request.Query["settingsId"];

        //    if (mrt != null)
        //    {
        //        report.Load(StiNetCoreHelper.MapPath(this, "Reports/" + mrt));
        //    }

        //    //   для каждой переменной находим  параметр из query string

        //    foreach ( StiVariable variable in report.Dictionary.Variables)
        //    {                              
        //      string queryParameterValue = HttpContext.Request.Query[variable.Name];
        //       if(queryParameterValue!=null)
        //            report.Dictionary.Variables[variable.Name].Value = queryParameterValue;
        //    }


        //    report.Render(false);
        //    return StiNetCoreViewer.GetReportResult(this, report);
        //    }



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
