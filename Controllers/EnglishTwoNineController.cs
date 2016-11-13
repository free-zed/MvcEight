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
    public class EnglishTwoNineController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwoNine
        public ActionResult Index()
        {
            return View(db.EnglishTwoNines.ToList());
        }

        // GET: EnglishTwoNine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoNine englishTwoNine = db.EnglishTwoNines.Find(id);
            if (englishTwoNine == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoNine);
        }

        // GET: EnglishTwoNine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwoNine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoNine englishTwoNine)
        {
            if (ModelState.IsValid)
            {
                englishTwoNine.Total = englishTwoNine.SBA + englishTwoNine.Final;
                if (englishTwoNine.Total >= 80)
                    englishTwoNine.GPA = 4.00;
                else if (englishTwoNine.Total >= 75 && englishTwoNine.Total < 80)
                    englishTwoNine.GPA = 3.75;
                else if (englishTwoNine.Total >= 70 && englishTwoNine.Total < 75)
                    englishTwoNine.GPA = 3.50;
                else if (englishTwoNine.Total >= 65 && englishTwoNine.Total < 70)
                    englishTwoNine.GPA = 3.25;
                else if (englishTwoNine.Total >= 60 && englishTwoNine.Total < 65)
                    englishTwoNine.GPA = 3.00;
                else if (englishTwoNine.Total >= 55 && englishTwoNine.Total < 60)
                    englishTwoNine.GPA = 2.75;
                else if (englishTwoNine.Total >= 50 && englishTwoNine.Total < 55)
                    englishTwoNine.GPA = 2.50;
                else if (englishTwoNine.Total >= 45 && englishTwoNine.Total < 50)
                    englishTwoNine.GPA = 2.25;
                else if (englishTwoNine.Total >= 40 && englishTwoNine.Total < 45)
                    englishTwoNine.GPA = 2.00;
                else if (englishTwoNine.Total < 40)
                    englishTwoNine.GPA = 0.00;

                if (englishTwoNine.Total >= 80)
                    englishTwoNine.Grade = "A+";
                else if (englishTwoNine.Total >= 75 && englishTwoNine.Total < 80)
                    englishTwoNine.Grade = "A";
                else if (englishTwoNine.Total >= 70 && englishTwoNine.Total < 75)
                    englishTwoNine.Grade = "A-";
                else if (englishTwoNine.Total >= 65 && englishTwoNine.Total < 70)
                    englishTwoNine.Grade = "B+";
                else if (englishTwoNine.Total >= 60 && englishTwoNine.Total < 65)
                    englishTwoNine.Grade = "B";
                else if (englishTwoNine.Total >= 55 && englishTwoNine.Total < 60)
                    englishTwoNine.Grade = "B-";
                else if (englishTwoNine.Total >= 50 && englishTwoNine.Total < 55)
                    englishTwoNine.Grade = "C+";
                else if (englishTwoNine.Total >= 45 && englishTwoNine.Total < 50)
                    englishTwoNine.Grade = "C";
                else if (englishTwoNine.Total >= 40 && englishTwoNine.Total < 45)
                    englishTwoNine.Grade = "D";
                else if (englishTwoNine.Total < 40)
                    englishTwoNine.Grade = "F";
                db.EnglishTwoNines.Add(englishTwoNine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwoNine);
        }

        // GET: EnglishTwoNine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoNine englishTwoNine = db.EnglishTwoNines.Find(id);
            if (englishTwoNine == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoNine);
        }

        // POST: EnglishTwoNine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoNine englishTwoNine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwoNine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwoNine);
        }

        // GET: EnglishTwoNine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoNine englishTwoNine = db.EnglishTwoNines.Find(id);
            if (englishTwoNine == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoNine);
        }

        // POST: EnglishTwoNine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwoNine englishTwoNine = db.EnglishTwoNines.Find(id);
            db.EnglishTwoNines.Remove(englishTwoNine);
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
