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
    public class EnglishTwoFiveController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwoFive
        public ActionResult Index()
        {
            return View(db.EnglishTwoFives.ToList());
        }

        // GET: EnglishTwoFive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoFive englishTwoFive = db.EnglishTwoFives.Find(id);
            if (englishTwoFive == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoFive);
        }

        // GET: EnglishTwoFive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwoFive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoFive englishTwoFive)
        {
            if (ModelState.IsValid)
            {
                englishTwoFive.Total = englishTwoFive.SBA + englishTwoFive.Final;
                if (englishTwoFive.Total >= 80)
                    englishTwoFive.GPA = 4.00;
                else if (englishTwoFive.Total >= 75 && englishTwoFive.Total < 80)
                    englishTwoFive.GPA = 3.75;
                else if (englishTwoFive.Total >= 70 && englishTwoFive.Total < 75)
                    englishTwoFive.GPA = 3.50;
                else if (englishTwoFive.Total >= 65 && englishTwoFive.Total < 70)
                    englishTwoFive.GPA = 3.25;
                else if (englishTwoFive.Total >= 60 && englishTwoFive.Total < 65)
                    englishTwoFive.GPA = 3.00;
                else if (englishTwoFive.Total >= 55 && englishTwoFive.Total < 60)
                    englishTwoFive.GPA = 2.75;
                else if (englishTwoFive.Total >= 50 && englishTwoFive.Total < 55)
                    englishTwoFive.GPA = 2.50;
                else if (englishTwoFive.Total >= 45 && englishTwoFive.Total < 50)
                    englishTwoFive.GPA = 2.25;
                else if (englishTwoFive.Total >= 40 && englishTwoFive.Total < 45)
                    englishTwoFive.GPA = 2.00;
                else if (englishTwoFive.Total < 40)
                    englishTwoFive.GPA = 0.00;

                if (englishTwoFive.Total >= 80)
                    englishTwoFive.Grade = "A+";
                else if (englishTwoFive.Total >= 75 && englishTwoFive.Total < 80)
                    englishTwoFive.Grade = "A";
                else if (englishTwoFive.Total >= 70 && englishTwoFive.Total < 75)
                    englishTwoFive.Grade = "A-";
                else if (englishTwoFive.Total >= 65 && englishTwoFive.Total < 70)
                    englishTwoFive.Grade = "B+";
                else if (englishTwoFive.Total >= 60 && englishTwoFive.Total < 65)
                    englishTwoFive.Grade = "B";
                else if (englishTwoFive.Total >= 55 && englishTwoFive.Total < 60)
                    englishTwoFive.Grade = "B-";
                else if (englishTwoFive.Total >= 50 && englishTwoFive.Total < 55)
                    englishTwoFive.Grade = "C+";
                else if (englishTwoFive.Total >= 45 && englishTwoFive.Total < 50)
                    englishTwoFive.Grade = "C";
                else if (englishTwoFive.Total >= 40 && englishTwoFive.Total < 45)
                    englishTwoFive.Grade = "D";
                else if (englishTwoFive.Total < 40)
                    englishTwoFive.Grade = "F";
                db.EnglishTwoFives.Add(englishTwoFive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwoFive);
        }

        // GET: EnglishTwoFive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoFive englishTwoFive = db.EnglishTwoFives.Find(id);
            if (englishTwoFive == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoFive);
        }

        // POST: EnglishTwoFive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoFive englishTwoFive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwoFive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwoFive);
        }

        // GET: EnglishTwoFive/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoFive englishTwoFive = db.EnglishTwoFives.Find(id);
            if (englishTwoFive == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoFive);
        }

        // POST: EnglishTwoFive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwoFive englishTwoFive = db.EnglishTwoFives.Find(id);
            db.EnglishTwoFives.Remove(englishTwoFive);
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
