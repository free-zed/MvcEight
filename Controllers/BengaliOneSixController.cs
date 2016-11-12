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
    public class BengaliOneSixController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliOneSix
        public ActionResult Index()
        {
            return View(db.BengaliOneSixs.ToList());
        }

        // GET: BengaliOneSix/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneSix bengaliOneSix = db.BengaliOneSixs.Find(id);
            if (bengaliOneSix == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneSix);
        }

        // GET: BengaliOneSix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliOneSix/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneSix bengaliOneSix)
        {
            if (ModelState.IsValid)
            {
                bengaliOneSix.Total = bengaliOneSix.SBA + bengaliOneSix.Final;
                if (bengaliOneSix.Total >= 80)
                    bengaliOneSix.GPA = 4.00;
                else if (bengaliOneSix.Total >= 75 && bengaliOneSix.Total < 80)
                    bengaliOneSix.GPA = 3.75;
                else if (bengaliOneSix.Total >= 70 && bengaliOneSix.Total < 75)
                    bengaliOneSix.GPA = 3.50;
                else if (bengaliOneSix.Total >= 65 && bengaliOneSix.Total < 70)
                    bengaliOneSix.GPA = 3.25;
                else if (bengaliOneSix.Total >= 60 && bengaliOneSix.Total < 65)
                    bengaliOneSix.GPA = 3.00;
                else if (bengaliOneSix.Total >= 55 && bengaliOneSix.Total < 60)
                    bengaliOneSix.GPA = 2.75;
                else if (bengaliOneSix.Total >= 50 && bengaliOneSix.Total < 55)
                    bengaliOneSix.GPA = 2.50;
                else if (bengaliOneSix.Total >= 45 && bengaliOneSix.Total < 50)
                    bengaliOneSix.GPA = 2.25;
                else if (bengaliOneSix.Total >= 40 && bengaliOneSix.Total < 45)
                    bengaliOneSix.GPA = 2.00;
                else if (bengaliOneSix.Total < 40)
                    bengaliOneSix.GPA = 0.00;

                if (bengaliOneSix.Total >= 80)
                    bengaliOneSix.Grade = "A+";
                else if (bengaliOneSix.Total >= 75 && bengaliOneSix.Total < 80)
                    bengaliOneSix.Grade = "A";
                else if (bengaliOneSix.Total >= 70 && bengaliOneSix.Total < 75)
                    bengaliOneSix.Grade = "A-";
                else if (bengaliOneSix.Total >= 65 && bengaliOneSix.Total < 70)
                    bengaliOneSix.Grade = "B+";
                else if (bengaliOneSix.Total >= 60 && bengaliOneSix.Total < 65)
                    bengaliOneSix.Grade = "B";
                else if (bengaliOneSix.Total >= 55 && bengaliOneSix.Total < 60)
                    bengaliOneSix.Grade = "B-";
                else if (bengaliOneSix.Total >= 50 && bengaliOneSix.Total < 55)
                    bengaliOneSix.Grade = "C+";
                else if (bengaliOneSix.Total >= 45 && bengaliOneSix.Total < 50)
                    bengaliOneSix.Grade = "C";
                else if (bengaliOneSix.Total >= 40 && bengaliOneSix.Total < 45)
                    bengaliOneSix.Grade = "D";
                else if (bengaliOneSix.Total < 40)
                    bengaliOneSix.Grade = "F";
                db.BengaliOneSixs.Add(bengaliOneSix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliOneSix);
        }

        // GET: BengaliOneSix/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneSix bengaliOneSix = db.BengaliOneSixs.Find(id);
            if (bengaliOneSix == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneSix);
        }

        // POST: BengaliOneSix/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneSix bengaliOneSix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliOneSix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliOneSix);
        }

        // GET: BengaliOneSix/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneSix bengaliOneSix = db.BengaliOneSixs.Find(id);
            if (bengaliOneSix == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneSix);
        }

        // POST: BengaliOneSix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliOneSix bengaliOneSix = db.BengaliOneSixs.Find(id);
            db.BengaliOneSixs.Remove(bengaliOneSix);
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
