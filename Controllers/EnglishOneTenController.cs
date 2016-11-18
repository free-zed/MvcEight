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
    public class EnglishOneTenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishOneTen
        public ActionResult Index()
        {
          
            return View(db.EnglishOneTens.ToList());
        }

        // GET: EnglishOneTen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneTen englishOneTen = db.EnglishOneTens.Find(id);
            if (englishOneTen == null)
            {
                return HttpNotFound();
            }
            return View(englishOneTen);
        }

        // GET: EnglishOneTen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishOneTen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneTen englishOneTen)
        {
            if (ModelState.IsValid)
            {
                englishOneTen.Total = englishOneTen.SBA + englishOneTen.Final;
                if (englishOneTen.Total >= 80)
                    englishOneTen.GPA = 4.00;
                else if (englishOneTen.Total >= 75 && englishOneTen.Total < 80)
                    englishOneTen.GPA = 3.75;
                else if (englishOneTen.Total >= 70 && englishOneTen.Total < 75)
                    englishOneTen.GPA = 3.50;
                else if (englishOneTen.Total >= 65 && englishOneTen.Total < 70)
                    englishOneTen.GPA = 3.25;
                else if (englishOneTen.Total >= 60 && englishOneTen.Total < 65)
                    englishOneTen.GPA = 3.00;
                else if (englishOneTen.Total >= 55 && englishOneTen.Total < 60)
                    englishOneTen.GPA = 2.75;
                else if (englishOneTen.Total >= 50 && englishOneTen.Total < 55)
                    englishOneTen.GPA = 2.50;
                else if (englishOneTen.Total >= 45 && englishOneTen.Total < 50)
                    englishOneTen.GPA = 2.25;
                else if (englishOneTen.Total >= 40 && englishOneTen.Total < 45)
                    englishOneTen.GPA = 2.00;
                else if (englishOneTen.Total < 40)
                    englishOneTen.GPA = 0.00;

                if (englishOneTen.Total >= 80)
                    englishOneTen.Grade = "A+";
                else if (englishOneTen.Total >= 75 && englishOneTen.Total < 80)
                    englishOneTen.Grade = "A";
                else if (englishOneTen.Total >= 70 && englishOneTen.Total < 75)
                    englishOneTen.Grade = "A-";
                else if (englishOneTen.Total >= 65 && englishOneTen.Total < 70)
                    englishOneTen.Grade = "B+";
                else if (englishOneTen.Total >= 60 && englishOneTen.Total < 65)
                    englishOneTen.Grade = "B";
                else if (englishOneTen.Total >= 55 && englishOneTen.Total < 60)
                    englishOneTen.Grade = "B-";
                else if (englishOneTen.Total >= 50 && englishOneTen.Total < 55)
                    englishOneTen.Grade = "C+";
                else if (englishOneTen.Total >= 45 && englishOneTen.Total < 50)
                    englishOneTen.Grade = "C";
                else if (englishOneTen.Total >= 40 && englishOneTen.Total < 45)
                    englishOneTen.Grade = "D";
                else if (englishOneTen.Total < 40)
                    englishOneTen.Grade = "F";
                db.EnglishOneTens.Add(englishOneTen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishOneTen);
        }

        // GET: EnglishOneTen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneTen englishOneTen = db.EnglishOneTens.Find(id);
            if (englishOneTen == null)
            {
                return HttpNotFound();
            }
            return View(englishOneTen);
        }

        // POST: EnglishOneTen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneTen englishOneTen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishOneTen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishOneTen);
        }

        // GET: EnglishOneTen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneTen englishOneTen = db.EnglishOneTens.Find(id);
            if (englishOneTen == null)
            {
                return HttpNotFound();
            }
            return View(englishOneTen);
        }

        // POST: EnglishOneTen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishOneTen englishOneTen = db.EnglishOneTens.Find(id);
            db.EnglishOneTens.Remove(englishOneTen);
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
