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
    public class EnglishOneSixController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishOneSix
        public ActionResult Index()
        {
            return View(db.EnglishOneSixs.ToList());
        }

        // GET: EnglishOneSix/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneSix englishOneSix = db.EnglishOneSixs.Find(id);
            if (englishOneSix == null)
            {
                return HttpNotFound();
            }
            return View(englishOneSix);
        }

        // GET: EnglishOneSix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishOneSix/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneSix englishOneSix)
        {
            if (ModelState.IsValid)
            {
                englishOneSix.Total = englishOneSix.SBA + englishOneSix.Final;
                if (englishOneSix.Total >= 80)
                    englishOneSix.GPA = 4.00;
                else if (englishOneSix.Total >= 75 && englishOneSix.Total < 80)
                    englishOneSix.GPA = 3.75;
                else if (englishOneSix.Total >= 70 && englishOneSix.Total < 75)
                    englishOneSix.GPA = 3.50;
                else if (englishOneSix.Total >= 65 && englishOneSix.Total < 70)
                    englishOneSix.GPA = 3.25;
                else if (englishOneSix.Total >= 60 && englishOneSix.Total < 65)
                    englishOneSix.GPA = 3.00;
                else if (englishOneSix.Total >= 55 && englishOneSix.Total < 60)
                    englishOneSix.GPA = 2.75;
                else if (englishOneSix.Total >= 50 && englishOneSix.Total < 55)
                    englishOneSix.GPA = 2.50;
                else if (englishOneSix.Total >= 45 && englishOneSix.Total < 50)
                    englishOneSix.GPA = 2.25;
                else if (englishOneSix.Total >= 40 && englishOneSix.Total < 45)
                    englishOneSix.GPA = 2.00;
                else if (englishOneSix.Total < 40)
                    englishOneSix.GPA = 0.00;

                if (englishOneSix.Total >= 80)
                    englishOneSix.Grade = "A+";
                else if (englishOneSix.Total >= 75 && englishOneSix.Total < 80)
                    englishOneSix.Grade = "A";
                else if (englishOneSix.Total >= 70 && englishOneSix.Total < 75)
                    englishOneSix.Grade = "A-";
                else if (englishOneSix.Total >= 65 && englishOneSix.Total < 70)
                    englishOneSix.Grade = "B+";
                else if (englishOneSix.Total >= 60 && englishOneSix.Total < 65)
                    englishOneSix.Grade = "B";
                else if (englishOneSix.Total >= 55 && englishOneSix.Total < 60)
                    englishOneSix.Grade = "B-";
                else if (englishOneSix.Total >= 50 && englishOneSix.Total < 55)
                    englishOneSix.Grade = "C+";
                else if (englishOneSix.Total >= 45 && englishOneSix.Total < 50)
                    englishOneSix.Grade = "C";
                else if (englishOneSix.Total >= 40 && englishOneSix.Total < 45)
                    englishOneSix.Grade = "D";
                else if (englishOneSix.Total < 40)
                    englishOneSix.Grade = "F";
                db.EnglishOneSixs.Add(englishOneSix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishOneSix);
        }

        // GET: EnglishOneSix/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneSix englishOneSix = db.EnglishOneSixs.Find(id);
            if (englishOneSix == null)
            {
                return HttpNotFound();
            }
            return View(englishOneSix);
        }

        // POST: EnglishOneSix/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneSix englishOneSix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishOneSix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishOneSix);
        }

        // GET: EnglishOneSix/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneSix englishOneSix = db.EnglishOneSixs.Find(id);
            if (englishOneSix == null)
            {
                return HttpNotFound();
            }
            return View(englishOneSix);
        }

        // POST: EnglishOneSix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishOneSix englishOneSix = db.EnglishOneSixs.Find(id);
            db.EnglishOneSixs.Remove(englishOneSix);
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
