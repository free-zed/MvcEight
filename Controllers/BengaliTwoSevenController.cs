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
    public class BengaliTwoSevenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwoSeven
        public ActionResult Index()
        {
            return View(db.BengaliTwoSevens.ToList());
        }

        // GET: BengaliTwoSeven/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoSeven bengaliTwoSeven = db.BengaliTwoSevens.Find(id);
            if (bengaliTwoSeven == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoSeven);
        }

        // GET: BengaliTwoSeven/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwoSeven/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoSeven bengaliTwoSeven)
        {
            if (ModelState.IsValid)
            {
                bengaliTwoSeven.Total = bengaliTwoSeven.SBA + bengaliTwoSeven.Final;
                if (bengaliTwoSeven.Total >= 80)
                    bengaliTwoSeven.GPA = 4.00;
                else if (bengaliTwoSeven.Total >= 75 && bengaliTwoSeven.Total < 80)
                    bengaliTwoSeven.GPA = 3.75;
                else if (bengaliTwoSeven.Total >= 70 && bengaliTwoSeven.Total < 75)
                    bengaliTwoSeven.GPA = 3.50;
                else if (bengaliTwoSeven.Total >= 65 && bengaliTwoSeven.Total < 70)
                    bengaliTwoSeven.GPA = 3.25;
                else if (bengaliTwoSeven.Total >= 60 && bengaliTwoSeven.Total < 65)
                    bengaliTwoSeven.GPA = 3.00;
                else if (bengaliTwoSeven.Total >= 55 && bengaliTwoSeven.Total < 60)
                    bengaliTwoSeven.GPA = 2.75;
                else if (bengaliTwoSeven.Total >= 50 && bengaliTwoSeven.Total < 55)
                    bengaliTwoSeven.GPA = 2.50;
                else if (bengaliTwoSeven.Total >= 45 && bengaliTwoSeven.Total < 50)
                    bengaliTwoSeven.GPA = 2.25;
                else if (bengaliTwoSeven.Total >= 40 && bengaliTwoSeven.Total < 45)
                    bengaliTwoSeven.GPA = 2.00;
                else if (bengaliTwoSeven.Total < 40)
                    bengaliTwoSeven.GPA = 0.00;

                if (bengaliTwoSeven.Total >= 80)
                    bengaliTwoSeven.Grade = "A+";
                else if (bengaliTwoSeven.Total >= 75 && bengaliTwoSeven.Total < 80)
                    bengaliTwoSeven.Grade = "A";
                else if (bengaliTwoSeven.Total >= 70 && bengaliTwoSeven.Total < 75)
                    bengaliTwoSeven.Grade = "A-";
                else if (bengaliTwoSeven.Total >= 65 && bengaliTwoSeven.Total < 70)
                    bengaliTwoSeven.Grade = "B+";
                else if (bengaliTwoSeven.Total >= 60 && bengaliTwoSeven.Total < 65)
                    bengaliTwoSeven.Grade = "B";
                else if (bengaliTwoSeven.Total >= 55 && bengaliTwoSeven.Total < 60)
                    bengaliTwoSeven.Grade = "B-";
                else if (bengaliTwoSeven.Total >= 50 && bengaliTwoSeven.Total < 55)
                    bengaliTwoSeven.Grade = "C+";
                else if (bengaliTwoSeven.Total >= 45 && bengaliTwoSeven.Total < 50)
                    bengaliTwoSeven.Grade = "C";
                else if (bengaliTwoSeven.Total >= 40 && bengaliTwoSeven.Total < 45)
                    bengaliTwoSeven.Grade = "D";
                else if (bengaliTwoSeven.Total < 40)
                    bengaliTwoSeven.Grade = "F";
                db.BengaliTwoSevens.Add(bengaliTwoSeven);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwoSeven);
        }

        // GET: BengaliTwoSeven/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoSeven bengaliTwoSeven = db.BengaliTwoSevens.Find(id);
            if (bengaliTwoSeven == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoSeven);
        }

        // POST: BengaliTwoSeven/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoSeven bengaliTwoSeven)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwoSeven).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwoSeven);
        }

        // GET: BengaliTwoSeven/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoSeven bengaliTwoSeven = db.BengaliTwoSevens.Find(id);
            if (bengaliTwoSeven == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoSeven);
        }

        // POST: BengaliTwoSeven/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwoSeven bengaliTwoSeven = db.BengaliTwoSevens.Find(id);
            db.BengaliTwoSevens.Remove(bengaliTwoSeven);
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
