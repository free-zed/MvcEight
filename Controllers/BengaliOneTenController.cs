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
    public class BengaliOneTenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliOneTen
        public ActionResult Index()
        {
            return View(db.BengaliOneTens.ToList());
        }

        // GET: BengaliOneTen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneTen bengaliOneTen = db.BengaliOneTens.Find(id);
            if (bengaliOneTen == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneTen);
        }

        // GET: BengaliOneTen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliOneTen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneTen bengaliOneTen)
        {
            if (ModelState.IsValid)
            {
                bengaliOneTen.Total = bengaliOneTen.SBA + bengaliOneTen.Final;
                if (bengaliOneTen.Total >= 80)
                    bengaliOneTen.GPA = 4.00;
                else if (bengaliOneTen.Total >= 75 && bengaliOneTen.Total < 80)
                    bengaliOneTen.GPA = 3.75;
                else if (bengaliOneTen.Total >= 70 && bengaliOneTen.Total < 75)
                    bengaliOneTen.GPA = 3.50;
                else if (bengaliOneTen.Total >= 65 && bengaliOneTen.Total < 70)
                    bengaliOneTen.GPA = 3.25;
                else if (bengaliOneTen.Total >= 60 && bengaliOneTen.Total < 65)
                    bengaliOneTen.GPA = 3.00;
                else if (bengaliOneTen.Total >= 55 && bengaliOneTen.Total < 60)
                    bengaliOneTen.GPA = 2.75;
                else if (bengaliOneTen.Total >= 50 && bengaliOneTen.Total < 55)
                    bengaliOneTen.GPA = 2.50;
                else if (bengaliOneTen.Total >= 45 && bengaliOneTen.Total < 50)
                    bengaliOneTen.GPA = 2.25;
                else if (bengaliOneTen.Total >= 40 && bengaliOneTen.Total < 45)
                    bengaliOneTen.GPA = 2.00;
                else if (bengaliOneTen.Total < 40)
                    bengaliOneTen.GPA = 0.00;

                if (bengaliOneTen.Total >= 80)
                    bengaliOneTen.Grade = "A+";
                else if (bengaliOneTen.Total >= 75 && bengaliOneTen.Total < 80)
                    bengaliOneTen.Grade = "A";
                else if (bengaliOneTen.Total >= 70 && bengaliOneTen.Total < 75)
                    bengaliOneTen.Grade = "A-";
                else if (bengaliOneTen.Total >= 65 && bengaliOneTen.Total < 70)
                    bengaliOneTen.Grade = "B+";
                else if (bengaliOneTen.Total >= 60 && bengaliOneTen.Total < 65)
                    bengaliOneTen.Grade = "B";
                else if (bengaliOneTen.Total >= 55 && bengaliOneTen.Total < 60)
                    bengaliOneTen.Grade = "B-";
                else if (bengaliOneTen.Total >= 50 && bengaliOneTen.Total < 55)
                    bengaliOneTen.Grade = "C+";
                else if (bengaliOneTen.Total >= 45 && bengaliOneTen.Total < 50)
                    bengaliOneTen.Grade = "C";
                else if (bengaliOneTen.Total >= 40 && bengaliOneTen.Total < 45)
                    bengaliOneTen.Grade = "D";
                else if (bengaliOneTen.Total < 40)
                    bengaliOneTen.Grade = "F";
                db.BengaliOneTens.Add(bengaliOneTen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliOneTen);
        }

        // GET: BengaliOneTen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneTen bengaliOneTen = db.BengaliOneTens.Find(id);
            if (bengaliOneTen == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneTen);
        }

        // POST: BengaliOneTen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliOneTen bengaliOneTen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliOneTen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliOneTen);
        }

        // GET: BengaliOneTen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliOneTen bengaliOneTen = db.BengaliOneTens.Find(id);
            if (bengaliOneTen == null)
            {
                return HttpNotFound();
            }
            return View(bengaliOneTen);
        }

        // POST: BengaliOneTen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliOneTen bengaliOneTen = db.BengaliOneTens.Find(id);
            db.BengaliOneTens.Remove(bengaliOneTen);
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
