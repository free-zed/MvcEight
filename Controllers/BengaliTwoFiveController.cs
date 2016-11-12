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
    public class BengaliTwoFiveController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwoFive
        public ActionResult Index()
        {
            return View(db.BengaliTwoFive.ToList());
        }

        // GET: BengaliTwoFive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoFive bengaliTwoFive = db.BengaliTwoFive.Find(id);
            if (bengaliTwoFive == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoFive);
        }

        // GET: BengaliTwoFive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwoFive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoFive bengaliTwoFive)
        {
            if (ModelState.IsValid)
            {
                bengaliTwoFive.Total = bengaliTwoFive.SBA + bengaliTwoFive.Final;
                if (bengaliTwoFive.Total >= 80)
                    bengaliTwoFive.GPA = 4.00;
                else if (bengaliTwoFive.Total >= 75 && bengaliTwoFive.Total < 80)
                    bengaliTwoFive.GPA = 3.75;
                else if (bengaliTwoFive.Total >= 70 && bengaliTwoFive.Total < 75)
                    bengaliTwoFive.GPA = 3.50;
                else if (bengaliTwoFive.Total >= 65 && bengaliTwoFive.Total < 70)
                    bengaliTwoFive.GPA = 3.25;
                else if (bengaliTwoFive.Total >= 60 && bengaliTwoFive.Total < 65)
                    bengaliTwoFive.GPA = 3.00;
                else if (bengaliTwoFive.Total >= 55 && bengaliTwoFive.Total < 60)
                    bengaliTwoFive.GPA = 2.75;
                else if (bengaliTwoFive.Total >= 50 && bengaliTwoFive.Total < 55)
                    bengaliTwoFive.GPA = 2.50;
                else if (bengaliTwoFive.Total >= 45 && bengaliTwoFive.Total < 50)
                    bengaliTwoFive.GPA = 2.25;
                else if (bengaliTwoFive.Total >= 40 && bengaliTwoFive.Total < 45)
                    bengaliTwoFive.GPA = 2.00;
                else if (bengaliTwoFive.Total < 40)
                    bengaliTwoFive.GPA = 0.00;

                if (bengaliTwoFive.Total >= 80)
                    bengaliTwoFive.Grade = "A+";
                else if (bengaliTwoFive.Total >= 75 && bengaliTwoFive.Total < 80)
                    bengaliTwoFive.Grade = "A";
                else if (bengaliTwoFive.Total >= 70 && bengaliTwoFive.Total < 75)
                    bengaliTwoFive.Grade = "A-";
                else if (bengaliTwoFive.Total >= 65 && bengaliTwoFive.Total < 70)
                    bengaliTwoFive.Grade = "B+";
                else if (bengaliTwoFive.Total >= 60 && bengaliTwoFive.Total < 65)
                    bengaliTwoFive.Grade = "B";
                else if (bengaliTwoFive.Total >= 55 && bengaliTwoFive.Total < 60)
                    bengaliTwoFive.Grade = "B-";
                else if (bengaliTwoFive.Total >= 50 && bengaliTwoFive.Total < 55)
                    bengaliTwoFive.Grade = "C+";
                else if (bengaliTwoFive.Total >= 45 && bengaliTwoFive.Total < 50)
                    bengaliTwoFive.Grade = "C";
                else if (bengaliTwoFive.Total >= 40 && bengaliTwoFive.Total < 45)
                    bengaliTwoFive.Grade = "D";
                else if (bengaliTwoFive.Total < 40)
                    bengaliTwoFive.Grade = "F";
                db.BengaliTwoFive.Add(bengaliTwoFive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwoFive);
        }

        // GET: BengaliTwoFive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoFive bengaliTwoFive = db.BengaliTwoFive.Find(id);
            if (bengaliTwoFive == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoFive);
        }

        // POST: BengaliTwoFive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoFive bengaliTwoFive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwoFive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwoFive);
        }

        // GET: BengaliTwoFive/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoFive bengaliTwoFive = db.BengaliTwoFive.Find(id);
            if (bengaliTwoFive == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoFive);
        }

        // POST: BengaliTwoFive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwoFive bengaliTwoFive = db.BengaliTwoFive.Find(id);
            db.BengaliTwoFive.Remove(bengaliTwoFive);
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
