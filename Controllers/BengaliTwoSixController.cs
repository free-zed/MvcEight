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
    public class BengaliTwoSixController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwoSix
        public ActionResult Index()
        {
            return View(db.BengaliTwoSixs.ToList());
        }

        // GET: BengaliTwoSix/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoSix bengaliTwoSix = db.BengaliTwoSixs.Find(id);
            if (bengaliTwoSix == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoSix);
        }

        // GET: BengaliTwoSix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwoSix/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoSix bengaliTwoSix)
        {
            if (ModelState.IsValid)
            {
                bengaliTwoSix.Total = bengaliTwoSix.SBA + bengaliTwoSix.Final;
                if (bengaliTwoSix.Total >= 80)
                    bengaliTwoSix.GPA = 4.00;
                else if (bengaliTwoSix.Total >= 75 && bengaliTwoSix.Total < 80)
                    bengaliTwoSix.GPA = 3.75;
                else if (bengaliTwoSix.Total >= 70 && bengaliTwoSix.Total < 75)
                    bengaliTwoSix.GPA = 3.50;
                else if (bengaliTwoSix.Total >= 65 && bengaliTwoSix.Total < 70)
                    bengaliTwoSix.GPA = 3.25;
                else if (bengaliTwoSix.Total >= 60 && bengaliTwoSix.Total < 65)
                    bengaliTwoSix.GPA = 3.00;
                else if (bengaliTwoSix.Total >= 55 && bengaliTwoSix.Total < 60)
                    bengaliTwoSix.GPA = 2.75;
                else if (bengaliTwoSix.Total >= 50 && bengaliTwoSix.Total < 55)
                    bengaliTwoSix.GPA = 2.50;
                else if (bengaliTwoSix.Total >= 45 && bengaliTwoSix.Total < 50)
                    bengaliTwoSix.GPA = 2.25;
                else if (bengaliTwoSix.Total >= 40 && bengaliTwoSix.Total < 45)
                    bengaliTwoSix.GPA = 2.00;
                else if (bengaliTwoSix.Total < 40)
                    bengaliTwoSix.GPA = 0.00;

                if (bengaliTwoSix.Total >= 80)
                    bengaliTwoSix.Grade = "A+";
                else if (bengaliTwoSix.Total >= 75 && bengaliTwoSix.Total < 80)
                    bengaliTwoSix.Grade = "A";
                else if (bengaliTwoSix.Total >= 70 && bengaliTwoSix.Total < 75)
                    bengaliTwoSix.Grade = "A-";
                else if (bengaliTwoSix.Total >= 65 && bengaliTwoSix.Total < 70)
                    bengaliTwoSix.Grade = "B+";
                else if (bengaliTwoSix.Total >= 60 && bengaliTwoSix.Total < 65)
                    bengaliTwoSix.Grade = "B";
                else if (bengaliTwoSix.Total >= 55 && bengaliTwoSix.Total < 60)
                    bengaliTwoSix.Grade = "B-";
                else if (bengaliTwoSix.Total >= 50 && bengaliTwoSix.Total < 55)
                    bengaliTwoSix.Grade = "C+";
                else if (bengaliTwoSix.Total >= 45 && bengaliTwoSix.Total < 50)
                    bengaliTwoSix.Grade = "C";
                else if (bengaliTwoSix.Total >= 40 && bengaliTwoSix.Total < 45)
                    bengaliTwoSix.Grade = "D";
                else if (bengaliTwoSix.Total < 40)
                    bengaliTwoSix.Grade = "F";
                db.BengaliTwoSixs.Add(bengaliTwoSix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwoSix);
        }

        // GET: BengaliTwoSix/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoSix bengaliTwoSix = db.BengaliTwoSixs.Find(id);
            if (bengaliTwoSix == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoSix);
        }

        // POST: BengaliTwoSix/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoSix bengaliTwoSix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwoSix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwoSix);
        }

        // GET: BengaliTwoSix/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoSix bengaliTwoSix = db.BengaliTwoSixs.Find(id);
            if (bengaliTwoSix == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoSix);
        }

        // POST: BengaliTwoSix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwoSix bengaliTwoSix = db.BengaliTwoSixs.Find(id);
            db.BengaliTwoSixs.Remove(bengaliTwoSix);
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
