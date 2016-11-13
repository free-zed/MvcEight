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
    public class BengaliOneNineController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliOneNine
        public ActionResult Index()
        {
            return View(db.BengaliOneNines.ToList());
        }

        // GET: BengaliOneNine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneNine bengaliOneNine = db.BengaliOneNines.Find(id);
            if (bengaliOneNine == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneNine);
        }

        // GET: BengaliOneNine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliOneNine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneNine bengaliOneNine)
        {
            if (ModelState.IsValid)
            {
                bengaliOneNine.Total = bengaliOneNine.SBA + bengaliOneNine.Final;
                if (bengaliOneNine.Total >= 80)
                    bengaliOneNine.GPA = 4.00;
                else if (bengaliOneNine.Total >= 75 && bengaliOneNine.Total < 80)
                    bengaliOneNine.GPA = 3.75;
                else if (bengaliOneNine.Total >= 70 && bengaliOneNine.Total < 75)
                    bengaliOneNine.GPA = 3.50;
                else if (bengaliOneNine.Total >= 65 && bengaliOneNine.Total < 70)
                    bengaliOneNine.GPA = 3.25;
                else if (bengaliOneNine.Total >= 60 && bengaliOneNine.Total < 65)
                    bengaliOneNine.GPA = 3.00;
                else if (bengaliOneNine.Total >= 55 && bengaliOneNine.Total < 60)
                    bengaliOneNine.GPA = 2.75;
                else if (bengaliOneNine.Total >= 50 && bengaliOneNine.Total < 55)
                    bengaliOneNine.GPA = 2.50;
                else if (bengaliOneNine.Total >= 45 && bengaliOneNine.Total < 50)
                    bengaliOneNine.GPA = 2.25;
                else if (bengaliOneNine.Total >= 40 && bengaliOneNine.Total < 45)
                    bengaliOneNine.GPA = 2.00;
                else if (bengaliOneNine.Total < 40)
                    bengaliOneNine.GPA = 0.00;

                if (bengaliOneNine.Total >= 80)
                    bengaliOneNine.Grade = "A+";
                else if (bengaliOneNine.Total >= 75 && bengaliOneNine.Total < 80)
                    bengaliOneNine.Grade = "A";
                else if (bengaliOneNine.Total >= 70 && bengaliOneNine.Total < 75)
                    bengaliOneNine.Grade = "A-";
                else if (bengaliOneNine.Total >= 65 && bengaliOneNine.Total < 70)
                    bengaliOneNine.Grade = "B+";
                else if (bengaliOneNine.Total >= 60 && bengaliOneNine.Total < 65)
                    bengaliOneNine.Grade = "B";
                else if (bengaliOneNine.Total >= 55 && bengaliOneNine.Total < 60)
                    bengaliOneNine.Grade = "B-";
                else if (bengaliOneNine.Total >= 50 && bengaliOneNine.Total < 55)
                    bengaliOneNine.Grade = "C+";
                else if (bengaliOneNine.Total >= 45 && bengaliOneNine.Total < 50)
                    bengaliOneNine.Grade = "C";
                else if (bengaliOneNine.Total >= 40 && bengaliOneNine.Total < 45)
                    bengaliOneNine.Grade = "D";
                else if (bengaliOneNine.Total < 40)
                    bengaliOneNine.Grade = "F";
                db.BengaliOneNines.Add(bengaliOneNine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliOneNine);
        }

        // GET: BengaliOneNine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneNine bengaliOneNine = db.BengaliOneNines.Find(id);
            if (bengaliOneNine == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneNine);
        }

        // POST: BengaliOneNine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneNine bengaliOneNine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliOneNine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliOneNine);
        }

        // GET: BengaliOneNine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneNine bengaliOneNine = db.BengaliOneNines.Find(id);
            if (bengaliOneNine == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneNine);
        }

        // POST: BengaliOneNine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliOneNine bengaliOneNine = db.BengaliOneNines.Find(id);
            db.BengaliOneNines.Remove(bengaliOneNine);
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
