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
    public class BengaliOneEightController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliOneEight
        public ActionResult Index()
        {
            return View(db.BengaliOneEights.ToList());
        }

        // GET: BengaliOneEight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneEight bengaliOneEight = db.BengaliOneEights.Find(id);
            if (bengaliOneEight == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneEight);
        }

        // GET: BengaliOneEight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliOneEight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneEight bengaliOneEight)
        {
            if (ModelState.IsValid)
            {
                bengaliOneEight.Total = bengaliOneEight.SBA + bengaliOneEight.Final;
                if (bengaliOneEight.Total >= 80)
                    bengaliOneEight.GPA = 4.00;
                else if (bengaliOneEight.Total >= 75 && bengaliOneEight.Total < 80)
                    bengaliOneEight.GPA = 3.75;
                else if (bengaliOneEight.Total >= 70 && bengaliOneEight.Total < 75)
                    bengaliOneEight.GPA = 3.50;
                else if (bengaliOneEight.Total >= 65 && bengaliOneEight.Total < 70)
                    bengaliOneEight.GPA = 3.25;
                else if (bengaliOneEight.Total >= 60 && bengaliOneEight.Total < 65)
                    bengaliOneEight.GPA = 3.00;
                else if (bengaliOneEight.Total >= 55 && bengaliOneEight.Total < 60)
                    bengaliOneEight.GPA = 2.75;
                else if (bengaliOneEight.Total >= 50 && bengaliOneEight.Total < 55)
                    bengaliOneEight.GPA = 2.50;
                else if (bengaliOneEight.Total >= 45 && bengaliOneEight.Total < 50)
                    bengaliOneEight.GPA = 2.25;
                else if (bengaliOneEight.Total >= 40 && bengaliOneEight.Total < 45)
                    bengaliOneEight.GPA = 2.00;
                else if (bengaliOneEight.Total < 40)
                    bengaliOneEight.GPA = 0.00;

                if (bengaliOneEight.Total >= 80)
                    bengaliOneEight.Grade = "A+";
                else if (bengaliOneEight.Total >= 75 && bengaliOneEight.Total < 80)
                    bengaliOneEight.Grade = "A";
                else if (bengaliOneEight.Total >= 70 && bengaliOneEight.Total < 75)
                    bengaliOneEight.Grade = "A-";
                else if (bengaliOneEight.Total >= 65 && bengaliOneEight.Total < 70)
                    bengaliOneEight.Grade = "B+";
                else if (bengaliOneEight.Total >= 60 && bengaliOneEight.Total < 65)
                    bengaliOneEight.Grade = "B";
                else if (bengaliOneEight.Total >= 55 && bengaliOneEight.Total < 60)
                    bengaliOneEight.Grade = "B-";
                else if (bengaliOneEight.Total >= 50 && bengaliOneEight.Total < 55)
                    bengaliOneEight.Grade = "C+";
                else if (bengaliOneEight.Total >= 45 && bengaliOneEight.Total < 50)
                    bengaliOneEight.Grade = "C";
                else if (bengaliOneEight.Total >= 40 && bengaliOneEight.Total < 45)
                    bengaliOneEight.Grade = "D";
                else if (bengaliOneEight.Total < 40)
                    bengaliOneEight.Grade = "F";
                db.BengaliOneEights.Add(bengaliOneEight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliOneEight);
        }

        // GET: BengaliOneEight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneEight bengaliOneEight = db.BengaliOneEights.Find(id);
            if (bengaliOneEight == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneEight);
        }

        // POST: BengaliOneEight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneEight bengaliOneEight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliOneEight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliOneEight);
        }

        // GET: BengaliOneEight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneEight bengaliOneEight = db.BengaliOneEights.Find(id);
            if (bengaliOneEight == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneEight);
        }

        // POST: BengaliOneEight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliOneEight bengaliOneEight = db.BengaliOneEights.Find(id);
            db.BengaliOneEights.Remove(bengaliOneEight);
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
