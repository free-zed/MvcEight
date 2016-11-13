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
    public class BengaliTwoNineController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwoNine
        public ActionResult Index()
        {
            return View(db.BengaliTwoNines.ToList());
        }

        // GET: BengaliTwoNine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoNine bengaliTwoNine = db.BengaliTwoNines.Find(id);
            if (bengaliTwoNine == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoNine);
        }

        // GET: BengaliTwoNine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwoNine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoNine bengaliTwoNine)
        {
            if (ModelState.IsValid)
            {
                bengaliTwoNine.Total = bengaliTwoNine.SBA + bengaliTwoNine.Final;
                if (bengaliTwoNine.Total >= 80)
                    bengaliTwoNine.GPA = 4.00;
                else if (bengaliTwoNine.Total >= 75 && bengaliTwoNine.Total < 80)
                    bengaliTwoNine.GPA = 3.75;
                else if (bengaliTwoNine.Total >= 70 && bengaliTwoNine.Total < 75)
                    bengaliTwoNine.GPA = 3.50;
                else if (bengaliTwoNine.Total >= 65 && bengaliTwoNine.Total < 70)
                    bengaliTwoNine.GPA = 3.25;
                else if (bengaliTwoNine.Total >= 60 && bengaliTwoNine.Total < 65)
                    bengaliTwoNine.GPA = 3.00;
                else if (bengaliTwoNine.Total >= 55 && bengaliTwoNine.Total < 60)
                    bengaliTwoNine.GPA = 2.75;
                else if (bengaliTwoNine.Total >= 50 && bengaliTwoNine.Total < 55)
                    bengaliTwoNine.GPA = 2.50;
                else if (bengaliTwoNine.Total >= 45 && bengaliTwoNine.Total < 50)
                    bengaliTwoNine.GPA = 2.25;
                else if (bengaliTwoNine.Total >= 40 && bengaliTwoNine.Total < 45)
                    bengaliTwoNine.GPA = 2.00;
                else if (bengaliTwoNine.Total < 40)
                    bengaliTwoNine.GPA = 0.00;

                if (bengaliTwoNine.Total >= 80)
                    bengaliTwoNine.Grade = "A+";
                else if (bengaliTwoNine.Total >= 75 && bengaliTwoNine.Total < 80)
                    bengaliTwoNine.Grade = "A";
                else if (bengaliTwoNine.Total >= 70 && bengaliTwoNine.Total < 75)
                    bengaliTwoNine.Grade = "A-";
                else if (bengaliTwoNine.Total >= 65 && bengaliTwoNine.Total < 70)
                    bengaliTwoNine.Grade = "B+";
                else if (bengaliTwoNine.Total >= 60 && bengaliTwoNine.Total < 65)
                    bengaliTwoNine.Grade = "B";
                else if (bengaliTwoNine.Total >= 55 && bengaliTwoNine.Total < 60)
                    bengaliTwoNine.Grade = "B-";
                else if (bengaliTwoNine.Total >= 50 && bengaliTwoNine.Total < 55)
                    bengaliTwoNine.Grade = "C+";
                else if (bengaliTwoNine.Total >= 45 && bengaliTwoNine.Total < 50)
                    bengaliTwoNine.Grade = "C";
                else if (bengaliTwoNine.Total >= 40 && bengaliTwoNine.Total < 45)
                    bengaliTwoNine.Grade = "D";
                else if (bengaliTwoNine.Total < 40)
                    bengaliTwoNine.Grade = "F";
                db.BengaliTwoNines.Add(bengaliTwoNine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwoNine);
        }

        // GET: BengaliTwoNine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoNine bengaliTwoNine = db.BengaliTwoNines.Find(id);
            if (bengaliTwoNine == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoNine);
        }

        // POST: BengaliTwoNine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoNine bengaliTwoNine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwoNine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwoNine);
        }

        // GET: BengaliTwoNine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoNine bengaliTwoNine = db.BengaliTwoNines.Find(id);
            if (bengaliTwoNine == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoNine);
        }

        // POST: BengaliTwoNine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwoNine bengaliTwoNine = db.BengaliTwoNines.Find(id);
            db.BengaliTwoNines.Remove(bengaliTwoNine);
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
