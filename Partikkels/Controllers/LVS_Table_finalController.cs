using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Partikkels.Models;

namespace Partikkels.Controllers
{
    public class LVS_Table_finalController : Controller
    {
        private Partikkels_F2018Entities db = new Partikkels_F2018Entities();
        private Partikkels_F2018Entities3 PartikkelView = new Partikkels_F2018Entities3();

        // GET: LVS_Table_final
        public ActionResult Index()
        {
            return View(db.LVS_Table_final.ToList());
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
        public ActionResult PartikelChart()
        {
            //DateTime a = DateTime.Parse("2015-02-13");
            var LvsMeasurements = db.LVS_Table_final.ToList();
            //var dailyResult = new List<MeasuringResult>();

            //dailyResult = measuringResult.ToList();

            string[] dateTimeArray = new string[8422];
            double[] resault = new double[8422];

            for (int i = 0; i < 8422; i++)
            {
                dateTimeArray[i] = LvsMeasurements[i].DatoMaerke.ToString();
            }

            for (int i = 0; i < 8422; i++)
            {
                if (LvsMeasurements[i].Resultat < 100 )
                resault[i] = (double)LvsMeasurements[i].Resultat;
            }

           
            var chart = new Chart(width: 1500, height: 400, theme:ChartTheme.Green)
                .AddSeries(chartType: "line", axisLabel:"PM10PM2,5",
                    xValue: dateTimeArray,
                    yValues: resault)
                .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult PM10Chart()
        {
          
            var LvsMeasurements = PartikkelView.Resault_PM10.ToList();
          

         

            string[] dateTimeArray = new string[4249];
            double[] resault = new double[4249];

            for (int i = 0; i < 4249; i++)
            {
                dateTimeArray[i] = LvsMeasurements[i].DatoMaerke.ToString();
            }

            for (int i = 0; i < 4249; i++)
            {
                if (LvsMeasurements[i].Resultat < 100)
                    resault[i] = (double)LvsMeasurements[i].Resultat;
            }


            var chart = new Chart(width: 1200, height: 400, theme:ChartTheme.Vanilla)
                .AddSeries(chartType: "line",
                    xValue: dateTimeArray,
                    yValues: resault)
                .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult PM25Chart()
        {
            //DateTime a = DateTime.Parse("2015-02-13");
            var LvsMeasurements = db.LVS_Table_final.ToList();
            //var dailyResult = new List<MeasuringResult>();

            //dailyResult = measuringResult.ToList();

            string[] dateTimeArray = new string[8422];
            double[] resault = new double[8422];

            for (int i = 0; i < 8422; i++)
            {
                dateTimeArray[i] = LvsMeasurements[i].DatoMaerke.ToString();
            }

            for (int i = 0; i < 8422; i++)
            {
                if (LvsMeasurements[i].Resultat < 100)
                    resault[i] = (double)LvsMeasurements[i].Resultat;
            }


            var chart = new Chart(width: 1500, height: 400)
                .AddSeries(chartType: "line",
                    xValue: dateTimeArray,
                    yValues: resault)
                .GetBytes("png");
            return File(chart, "image/bytes");
        }

        // GET: LVS_Table_final/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVS_Table_final lVS_Table_final = db.LVS_Table_final.Find(id);
            if (lVS_Table_final == null)
            {
                return HttpNotFound();
            }
            return View(lVS_Table_final);
        }

        // GET: LVS_Table_final/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LVS_Table_final/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaalestedId,Maalested,DatoMaerke,StofId,StofNavn,EnhedId,Enhed,Resultat,UdstyrId,Navn")] LVS_Table_final lVS_Table_final)
        {
            if (ModelState.IsValid)
            {
                db.LVS_Table_final.Add(lVS_Table_final);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lVS_Table_final);
        }

        // GET: LVS_Table_final/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVS_Table_final lVS_Table_final = db.LVS_Table_final.Find(id);
            if (lVS_Table_final == null)
            {
                return HttpNotFound();
            }
            return View(lVS_Table_final);
        }

        // POST: LVS_Table_final/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaalestedId,Maalested,DatoMaerke,StofId,StofNavn,EnhedId,Enhed,Resultat,UdstyrId,Navn")] LVS_Table_final lVS_Table_final)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lVS_Table_final).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lVS_Table_final);
        }

        // GET: LVS_Table_final/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LVS_Table_final lVS_Table_final = db.LVS_Table_final.Find(id);
            if (lVS_Table_final == null)
            {
                return HttpNotFound();
            }
            return View(lVS_Table_final);
        }

        // POST: LVS_Table_final/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LVS_Table_final lVS_Table_final = db.LVS_Table_final.Find(id);
            db.LVS_Table_final.Remove(lVS_Table_final);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
