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
    public class EnglishOneFiveController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishOneFive
        public ActionResult Index()
        {
            return View(db.EnglishOneFives.ToList());
        }

        // GET: EnglishOneFive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneFive englishOneFive = db.EnglishOneFives.Find(id);
            if (englishOneFive == null)
            {
                return HttpNotFound();
            }
            return View(englishOneFive);
        }

        // GET: EnglishOneFive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishOneFive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneFive englishOneFive)
        {
            if (ModelState.IsValid)
            {
                englishOneFive.Total = englishOneFive.SBA + englishOneFive.Final;
                if (englishOneFive.Total >= 80)
                    englishOneFive.GPA = 4.00;
                else if (englishOneFive.Total >= 75 && englishOneFive.Total < 80)
                    englishOneFive.GPA = 3.75;
                else if (englishOneFive.Total >= 70 && englishOneFive.Total < 75)
                    englishOneFive.GPA = 3.50;
                else if (englishOneFive.Total >= 65 && englishOneFive.Total < 70)
                    englishOneFive.GPA = 3.25;
                else if (englishOneFive.Total >= 60 && englishOneFive.Total < 65)
                    englishOneFive.GPA = 3.00;
                else if (englishOneFive.Total >= 55 && englishOneFive.Total < 60)
                    englishOneFive.GPA = 2.75;
                else if (englishOneFive.Total >= 50 && englishOneFive.Total < 55)
                    englishOneFive.GPA = 2.50;
                else if (englishOneFive.Total >= 45 && englishOneFive.Total < 50)
                    englishOneFive.GPA = 2.25;
                else if (englishOneFive.Total >= 40 && englishOneFive.Total < 45)
                    englishOneFive.GPA = 2.00;
                else if (englishOneFive.Total < 40)
                    englishOneFive.GPA = 0.00;

                if (englishOneFive.Total >= 80)
                    englishOneFive.Grade = "A+";
                else if (englishOneFive.Total >= 75 && englishOneFive.Total < 80)
                    englishOneFive.Grade = "A";
                else if (englishOneFive.Total >= 70 && englishOneFive.Total < 75)
                    englishOneFive.Grade = "A-";
                else if (englishOneFive.Total >= 65 && englishOneFive.Total < 70)
                    englishOneFive.Grade = "B+";
                else if (englishOneFive.Total >= 60 && englishOneFive.Total < 65)
                    englishOneFive.Grade = "B";
                else if (englishOneFive.Total >= 55 && englishOneFive.Total < 60)
                    englishOneFive.Grade = "B-";
                else if (englishOneFive.Total >= 50 && englishOneFive.Total < 55)
                    englishOneFive.Grade = "C+";
                else if (englishOneFive.Total >= 45 && englishOneFive.Total < 50)
                    englishOneFive.Grade = "C";
                else if (englishOneFive.Total >= 40 && englishOneFive.Total < 45)
                    englishOneFive.Grade = "D";
                else if (englishOneFive.Total < 40)
                    englishOneFive.Grade = "F";
                db.EnglishOneFives.Add(englishOneFive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishOneFive);
        }

        // GET: EnglishOneFive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneFive englishOneFive = db.EnglishOneFives.Find(id);
            if (englishOneFive == null)
            {
                return HttpNotFound();
            }
            return View(englishOneFive);
        }

        // POST: EnglishOneFive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneFive englishOneFive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishOneFive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishOneFive);
        }

        // GET: EnglishOneFive/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneFive englishOneFive = db.EnglishOneFives.Find(id);
            if (englishOneFive == null)
            {
                return HttpNotFound();
            }
            return View(englishOneFive);
        }

        // POST: EnglishOneFive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishOneFive englishOneFive = db.EnglishOneFives.Find(id);
            db.EnglishOneFives.Remove(englishOneFive);
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
