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
    public class BengaliTwoTenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwoTen
        public ActionResult Index()
        {
            return View(db.BengaliTwoTens.ToList());
        }

        // GET: BengaliTwoTen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoTen bengaliTwoTen = db.BengaliTwoTens.Find(id);
            if (bengaliTwoTen == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoTen);
        }

        // GET: BengaliTwoTen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwoTen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoTen bengaliTwoTen)
        {
            if (ModelState.IsValid)
            {
                bengaliTwoTen.Total = bengaliTwoTen.SBA + bengaliTwoTen.Final;
                if (bengaliTwoTen.Total >= 80)
                    bengaliTwoTen.GPA = 4.00;
                else if (bengaliTwoTen.Total >= 75 && bengaliTwoTen.Total < 80)
                    bengaliTwoTen.GPA = 3.75;
                else if (bengaliTwoTen.Total >= 70 && bengaliTwoTen.Total < 75)
                    bengaliTwoTen.GPA = 3.50;
                else if (bengaliTwoTen.Total >= 65 && bengaliTwoTen.Total < 70)
                    bengaliTwoTen.GPA = 3.25;
                else if (bengaliTwoTen.Total >= 60 && bengaliTwoTen.Total < 65)
                    bengaliTwoTen.GPA = 3.00;
                else if (bengaliTwoTen.Total >= 55 && bengaliTwoTen.Total < 60)
                    bengaliTwoTen.GPA = 2.75;
                else if (bengaliTwoTen.Total >= 50 && bengaliTwoTen.Total < 55)
                    bengaliTwoTen.GPA = 2.50;
                else if (bengaliTwoTen.Total >= 45 && bengaliTwoTen.Total < 50)
                    bengaliTwoTen.GPA = 2.25;
                else if (bengaliTwoTen.Total >= 40 && bengaliTwoTen.Total < 45)
                    bengaliTwoTen.GPA = 2.00;
                else if (bengaliTwoTen.Total < 40)
                    bengaliTwoTen.GPA = 0.00;

                if (bengaliTwoTen.Total >= 80)
                    bengaliTwoTen.Grade = "A+";
                else if (bengaliTwoTen.Total >= 75 && bengaliTwoTen.Total < 80)
                    bengaliTwoTen.Grade = "A";
                else if (bengaliTwoTen.Total >= 70 && bengaliTwoTen.Total < 75)
                    bengaliTwoTen.Grade = "A-";
                else if (bengaliTwoTen.Total >= 65 && bengaliTwoTen.Total < 70)
                    bengaliTwoTen.Grade = "B+";
                else if (bengaliTwoTen.Total >= 60 && bengaliTwoTen.Total < 65)
                    bengaliTwoTen.Grade = "B";
                else if (bengaliTwoTen.Total >= 55 && bengaliTwoTen.Total < 60)
                    bengaliTwoTen.Grade = "B-";
                else if (bengaliTwoTen.Total >= 50 && bengaliTwoTen.Total < 55)
                    bengaliTwoTen.Grade = "C+";
                else if (bengaliTwoTen.Total >= 45 && bengaliTwoTen.Total < 50)
                    bengaliTwoTen.Grade = "C";
                else if (bengaliTwoTen.Total >= 40 && bengaliTwoTen.Total < 45)
                    bengaliTwoTen.Grade = "D";
                else if (bengaliTwoTen.Total < 40)
                    bengaliTwoTen.Grade = "F";
                db.BengaliTwoTens.Add(bengaliTwoTen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwoTen);
        }

        // GET: BengaliTwoTen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoTen bengaliTwoTen = db.BengaliTwoTens.Find(id);
            if (bengaliTwoTen == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoTen);
        }

        // POST: BengaliTwoTen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwoTen bengaliTwoTen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwoTen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwoTen);
        }

        // GET: BengaliTwoTen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwoTen bengaliTwoTen = db.BengaliTwoTens.Find(id);
            if (bengaliTwoTen == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwoTen);
        }

        // POST: BengaliTwoTen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwoTen bengaliTwoTen = db.BengaliTwoTens.Find(id);
            db.BengaliTwoTens.Remove(bengaliTwoTen);
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
