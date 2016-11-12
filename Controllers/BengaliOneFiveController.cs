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
    public class BengaliOneFiveController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliOneFive
        public ActionResult Index()
        {
            return View(db.BengaliOneFives.ToList());
        }

        // GET: BengaliOneFive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneFive bengaliOneFive = db.BengaliOneFives.Find(id);
            if (bengaliOneFive == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneFive);
        }

        // GET: BengaliOneFive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliOneFive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneFive bengaliOneFive)
        {
            if (ModelState.IsValid)
            {
                bengaliOneFive.Total = bengaliOneFive.SBA + bengaliOneFive.Final;
                if (bengaliOneFive.Total >= 80)
                    bengaliOneFive.GPA = 4.00;
                else if (bengaliOneFive.Total >= 75 && bengaliOneFive.Total < 80)
                    bengaliOneFive.GPA = 3.75;
                else if (bengaliOneFive.Total >= 70 && bengaliOneFive.Total < 75)
                    bengaliOneFive.GPA = 3.50;
                else if (bengaliOneFive.Total >= 65 && bengaliOneFive.Total < 70)
                    bengaliOneFive.GPA = 3.25;
                else if (bengaliOneFive.Total >= 60 && bengaliOneFive.Total < 65)
                    bengaliOneFive.GPA = 3.00;
                else if (bengaliOneFive.Total >= 55 && bengaliOneFive.Total < 60)
                    bengaliOneFive.GPA = 2.75;
                else if (bengaliOneFive.Total >= 50 && bengaliOneFive.Total < 55)
                    bengaliOneFive.GPA = 2.50;
                else if (bengaliOneFive.Total >= 45 && bengaliOneFive.Total < 50)
                    bengaliOneFive.GPA = 2.25;
                else if (bengaliOneFive.Total >= 40 && bengaliOneFive.Total < 45)
                    bengaliOneFive.GPA = 2.00;
                else if (bengaliOneFive.Total < 40)
                    bengaliOneFive.GPA = 0.00;

                if (bengaliOneFive.Total >= 80)
                    bengaliOneFive.Grade = "A+";
                else if (bengaliOneFive.Total >= 75 && bengaliOneFive.Total < 80)
                    bengaliOneFive.Grade = "A";
                else if (bengaliOneFive.Total >= 70 && bengaliOneFive.Total < 75)
                    bengaliOneFive.Grade = "A-";
                else if (bengaliOneFive.Total >= 65 && bengaliOneFive.Total < 70)
                    bengaliOneFive.Grade = "B+";
                else if (bengaliOneFive.Total >= 60 && bengaliOneFive.Total < 65)
                    bengaliOneFive.Grade = "B";
                else if (bengaliOneFive.Total >= 55 && bengaliOneFive.Total < 60)
                    bengaliOneFive.Grade = "B-";
                else if (bengaliOneFive.Total >= 50 && bengaliOneFive.Total < 55)
                    bengaliOneFive.Grade = "C+";
                else if (bengaliOneFive.Total >= 45 && bengaliOneFive.Total < 50)
                    bengaliOneFive.Grade = "C";
                else if (bengaliOneFive.Total >= 40 && bengaliOneFive.Total < 45)
                    bengaliOneFive.Grade = "D";
                else if (bengaliOneFive.Total < 40)
                    bengaliOneFive.Grade = "F";
                db.BengaliOneFives.Add(bengaliOneFive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliOneFive);
        }

        // GET: BengaliOneFive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneFive bengaliOneFive = db.BengaliOneFives.Find(id);
            if (bengaliOneFive == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneFive);
        }

        // POST: BengaliOneFive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneFive bengaliOneFive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliOneFive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliOneFive);
        }

        // GET: BengaliOneFive/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneFive bengaliOneFive = db.BengaliOneFives.Find(id);
            if (bengaliOneFive == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneFive);
        }

        // POST: BengaliOneFive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliOneFive bengaliOneFive = db.BengaliOneFives.Find(id);
            db.BengaliOneFives.Remove(bengaliOneFive);
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
