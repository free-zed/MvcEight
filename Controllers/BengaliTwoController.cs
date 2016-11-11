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
    public class BengaliTwoController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliTwo
        public ActionResult Index()
        {
            return View(db.BengaliTwos.ToList());
        }

        // GET: BengaliTwo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwo bengaliTwo = db.BengaliTwos.Find(id);
            if (bengaliTwo == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwo);
        }

        // GET: BengaliTwo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliTwo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwo bengaliTwo)
        {
            if (ModelState.IsValid)
            {
                bengaliTwo.Total = bengaliTwo.SBA + bengaliTwo.Final;
                if (bengaliTwo.Total >= 80)
                    bengaliTwo.GPA = 4.00;
                else if (bengaliTwo.Total >= 75 && bengaliTwo.Total < 80)
                    bengaliTwo.GPA = 3.75;
                else if (bengaliTwo.Total >= 70 && bengaliTwo.Total < 75)
                    bengaliTwo.GPA = 3.50;
                else if (bengaliTwo.Total >= 65 && bengaliTwo.Total < 70)
                    bengaliTwo.GPA = 3.25;
                else if (bengaliTwo.Total >= 60 && bengaliTwo.Total < 65)
                    bengaliTwo.GPA = 3.00;
                else if (bengaliTwo.Total >= 55 && bengaliTwo.Total < 60)
                    bengaliTwo.GPA = 2.75;
                else if (bengaliTwo.Total >= 50 && bengaliTwo.Total < 55)
                    bengaliTwo.GPA = 2.50;
                else if (bengaliTwo.Total >= 45 && bengaliTwo.Total < 50)
                    bengaliTwo.GPA = 2.25;
                else if (bengaliTwo.Total >= 40 && bengaliTwo.Total < 45)
                    bengaliTwo.GPA = 2.00;
                else if (bengaliTwo.Total < 40)
                    bengaliTwo.GPA = 0.00;

                if (bengaliTwo.Total >= 80)
                    bengaliTwo.Grade = "A+";
                else if (bengaliTwo.Total >= 75 && bengaliTwo.Total < 80)
                    bengaliTwo.Grade = "A";
                else if (bengaliTwo.Total >= 70 && bengaliTwo.Total < 75)
                    bengaliTwo.Grade = "A-";
                else if (bengaliTwo.Total >= 65 && bengaliTwo.Total < 70)
                    bengaliTwo.Grade = "B+";
                else if (bengaliTwo.Total >= 60 && bengaliTwo.Total < 65)
                    bengaliTwo.Grade = "B";
                else if (bengaliTwo.Total >= 55 && bengaliTwo.Total < 60)
                    bengaliTwo.Grade = "B-";
                else if (bengaliTwo.Total >= 50 && bengaliTwo.Total < 55)
                    bengaliTwo.Grade = "C+";
                else if (bengaliTwo.Total >= 45 && bengaliTwo.Total < 50)
                    bengaliTwo.Grade = "C";
                else if (bengaliTwo.Total >= 40 && bengaliTwo.Total < 45)
                    bengaliTwo.Grade = "D";
                else if (bengaliTwo.Total < 40)
                    bengaliTwo.Grade = "F";
                db.BengaliTwos.Add(bengaliTwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliTwo);
        }

        // GET: BengaliTwo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwo bengaliTwo = db.BengaliTwos.Find(id);
            if (bengaliTwo == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwo);
        }

        // POST: BengaliTwo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliTwo bengaliTwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliTwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliTwo);
        }

        // GET: BengaliTwo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliTwo bengaliTwo = db.BengaliTwos.Find(id);
            if (bengaliTwo == null)
            {
                return HttpNotFound();
            }
            return View(bengaliTwo);
        }

        // POST: BengaliTwo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliTwo bengaliTwo = db.BengaliTwos.Find(id);
            db.BengaliTwos.Remove(bengaliTwo);
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
