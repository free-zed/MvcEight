using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcEight.DAL;
using MvcEight.Models;

namespace MvcEight.Controllers
{
    public class BengaliOneSevenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliOneSeven
        public ActionResult Index()
        {
            return View(db.BengaliOneSevens.ToList());
        }

        // GET: BengaliOneSeven/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneSeven bengaliOneSeven = db.BengaliOneSevens.Find(id);
            if (bengaliOneSeven == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneSeven);
        }

        // GET: BengaliOneSeven/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliOneSeven/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneSeven bengaliOneSeven)
        {
            if (ModelState.IsValid)
            {
                bengaliOneSeven.Total = bengaliOneSeven.SBA + bengaliOneSeven.Final;
                if (bengaliOneSeven.Total >= 80)
                    bengaliOneSeven.GPA = 4.00;
                else if (bengaliOneSeven.Total >= 75 && bengaliOneSeven.Total < 80)
                    bengaliOneSeven.GPA = 3.75;
                else if (bengaliOneSeven.Total >= 70 && bengaliOneSeven.Total < 75)
                    bengaliOneSeven.GPA = 3.50;
                else if (bengaliOneSeven.Total >= 65 && bengaliOneSeven.Total < 70)
                    bengaliOneSeven.GPA = 3.25;
                else if (bengaliOneSeven.Total >= 60 && bengaliOneSeven.Total < 65)
                    bengaliOneSeven.GPA = 3.00;
                else if (bengaliOneSeven.Total >= 55 && bengaliOneSeven.Total < 60)
                    bengaliOneSeven.GPA = 2.75;
                else if (bengaliOneSeven.Total >= 50 && bengaliOneSeven.Total < 55)
                    bengaliOneSeven.GPA = 2.50;
                else if (bengaliOneSeven.Total >= 45 && bengaliOneSeven.Total < 50)
                    bengaliOneSeven.GPA = 2.25;
                else if (bengaliOneSeven.Total >= 40 && bengaliOneSeven.Total < 45)
                    bengaliOneSeven.GPA = 2.00;
                else if (bengaliOneSeven.Total < 40)
                    bengaliOneSeven.GPA = 0.00;

                if (bengaliOneSeven.Total >= 80)
                    bengaliOneSeven.Grade = "A+";
                else if (bengaliOneSeven.Total >= 75 && bengaliOneSeven.Total < 80)
                    bengaliOneSeven.Grade = "A";
                else if (bengaliOneSeven.Total >= 70 && bengaliOneSeven.Total < 75)
                    bengaliOneSeven.Grade = "A-";
                else if (bengaliOneSeven.Total >= 65 && bengaliOneSeven.Total < 70)
                    bengaliOneSeven.Grade = "B+";
                else if (bengaliOneSeven.Total >= 60 && bengaliOneSeven.Total < 65)
                    bengaliOneSeven.Grade = "B";
                else if (bengaliOneSeven.Total >= 55 && bengaliOneSeven.Total < 60)
                    bengaliOneSeven.Grade = "B-";
                else if (bengaliOneSeven.Total >= 50 && bengaliOneSeven.Total < 55)
                    bengaliOneSeven.Grade = "C+";
                else if (bengaliOneSeven.Total >= 45 && bengaliOneSeven.Total < 50)
                    bengaliOneSeven.Grade = "C";
                else if (bengaliOneSeven.Total >= 40 && bengaliOneSeven.Total < 45)
                    bengaliOneSeven.Grade = "D";
                else if (bengaliOneSeven.Total < 40)
                    bengaliOneSeven.Grade = "F";
                db.BengaliOneSevens.Add(bengaliOneSeven);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliOneSeven);
        }

        // GET: BengaliOneSeven/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneSeven bengaliOneSeven = db.BengaliOneSevens.Find(id);
            if (bengaliOneSeven == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneSeven);
        }

        // POST: BengaliOneSeven/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneSeven bengaliOneSeven)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliOneSeven).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliOneSeven);
        }

        // GET: BengaliOneSeven/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneSeven bengaliOneSeven = db.BengaliOneSevens.Find(id);
            if (bengaliOneSeven == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneSeven);
        }

        // POST: BengaliOneSeven/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliOneSeven bengaliOneSeven = db.BengaliOneSevens.Find(id);
            db.BengaliOneSevens.Remove(bengaliOneSeven);
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
