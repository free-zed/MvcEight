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
    public class BengaliTwoEightController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwoEight
        public ActionResult Index()
        {
            return View(db.BengaliTwoEights.ToList());
        }

        // GET: BengaliTwoEight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoEight bengaliTwoEight = db.BengaliTwoEights.Find(id);
            if (bengaliTwoEight == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoEight);
        }

        // GET: BengaliTwoEight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwoEight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoEight bengaliTwoEight)
        {
            if (ModelState.IsValid)
            {
                bengaliTwoEight.Total = bengaliTwoEight.SBA + bengaliTwoEight.Final;
                if (bengaliTwoEight.Total >= 80)
                    bengaliTwoEight.GPA = 4.00;
                else if (bengaliTwoEight.Total >= 75 && bengaliTwoEight.Total < 80)
                    bengaliTwoEight.GPA = 3.75;
                else if (bengaliTwoEight.Total >= 70 && bengaliTwoEight.Total < 75)
                    bengaliTwoEight.GPA = 3.50;
                else if (bengaliTwoEight.Total >= 65 && bengaliTwoEight.Total < 70)
                    bengaliTwoEight.GPA = 3.25;
                else if (bengaliTwoEight.Total >= 60 && bengaliTwoEight.Total < 65)
                    bengaliTwoEight.GPA = 3.00;
                else if (bengaliTwoEight.Total >= 55 && bengaliTwoEight.Total < 60)
                    bengaliTwoEight.GPA = 2.75;
                else if (bengaliTwoEight.Total >= 50 && bengaliTwoEight.Total < 55)
                    bengaliTwoEight.GPA = 2.50;
                else if (bengaliTwoEight.Total >= 45 && bengaliTwoEight.Total < 50)
                    bengaliTwoEight.GPA = 2.25;
                else if (bengaliTwoEight.Total >= 40 && bengaliTwoEight.Total < 45)
                    bengaliTwoEight.GPA = 2.00;
                else if (bengaliTwoEight.Total < 40)
                    bengaliTwoEight.GPA = 0.00;

                if (bengaliTwoEight.Total >= 80)
                    bengaliTwoEight.Grade = "A+";
                else if (bengaliTwoEight.Total >= 75 && bengaliTwoEight.Total < 80)
                    bengaliTwoEight.Grade = "A";
                else if (bengaliTwoEight.Total >= 70 && bengaliTwoEight.Total < 75)
                    bengaliTwoEight.Grade = "A-";
                else if (bengaliTwoEight.Total >= 65 && bengaliTwoEight.Total < 70)
                    bengaliTwoEight.Grade = "B+";
                else if (bengaliTwoEight.Total >= 60 && bengaliTwoEight.Total < 65)
                    bengaliTwoEight.Grade = "B";
                else if (bengaliTwoEight.Total >= 55 && bengaliTwoEight.Total < 60)
                    bengaliTwoEight.Grade = "B-";
                else if (bengaliTwoEight.Total >= 50 && bengaliTwoEight.Total < 55)
                    bengaliTwoEight.Grade = "C+";
                else if (bengaliTwoEight.Total >= 45 && bengaliTwoEight.Total < 50)
                    bengaliTwoEight.Grade = "C";
                else if (bengaliTwoEight.Total >= 40 && bengaliTwoEight.Total < 45)
                    bengaliTwoEight.Grade = "D";
                else if (bengaliTwoEight.Total < 40)
                    bengaliTwoEight.Grade = "F";
                db.BengaliTwoEights.Add(bengaliTwoEight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwoEight);
        }

        // GET: BengaliTwoEight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoEight bengaliTwoEight = db.BengaliTwoEights.Find(id);
            if (bengaliTwoEight == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoEight);
        }

        // POST: BengaliTwoEight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoEight bengaliTwoEight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwoEight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwoEight);
        }

        // GET: BengaliTwoEight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoEight bengaliTwoEight = db.BengaliTwoEights.Find(id);
            if (bengaliTwoEight == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoEight);
        }

        // POST: BengaliTwoEight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwoEight bengaliTwoEight = db.BengaliTwoEights.Find(id);
            db.BengaliTwoEights.Remove(bengaliTwoEight);
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
