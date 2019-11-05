using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Measurements2018.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Measurements2018.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirData2018Context ctx = new AirData2018Context();
        public ActionResult Index()
        {
            //var measurements = ctx.Measurements.AsQueryable();
            var measurements = ctx.Measurements.Find(b => b.StuffName.Equals("Ozon")).ToList();
            return View(measurements);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OzonChart()
        {
           
            var measurements = ctx.Measurements.Find(b => b.StuffName.Equals("Ozon")).ToList();
            

            string[] dateTimeArray = new string[measurements.Count+1];
            double[] resault = new double[measurements.Count + 1];

            for (int i = 0; i < measurements.Count; i++)
            {
                dateTimeArray[i] = measurements[i].TimeStamp.ToString();
            }

            for (int i = 0; i < measurements.Count; i++)
            {
                if (measurements[i].Result < 100)
                    resault[i] = (double)measurements[i].Result;
            }


            var chart = new Chart(width: 550, height: 200, theme: ChartTheme.Green)
                .AddSeries(chartType: "line", axisLabel: "Ozon",
                    xValue: dateTimeArray,
                    yValues: resault)
                .GetBytes("png");
            return File(chart, "image/bytes");
        }


        public ActionResult CreateLineChart1()
        {

            //Create bar chart
            var chart = new Chart(width: 400, height: 200)
                .AddSeries(chartType: "line",
                    xValue: new[] { "10 ", "50", "30 ", "70" },
                    yValues: new[] { "50", "70", "90", "110" })
                .GetBytes("png");

            return File(chart, "image/bytes");
        }
    }
}