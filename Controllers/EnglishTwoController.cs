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
    public class EnglishTwoController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwo
        public ActionResult Index()
        {
            return View(db.EnglishTwo.ToList());
        }

        // GET: EnglishTwo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwo englishTwo = db.EnglishTwo.Find(id);
            if (englishTwo == null)
            {
                return HttpNotFound();
            }
            return View(englishTwo);
        }

        // GET: EnglishTwo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwo englishTwo)
        {
            if (ModelState.IsValid)
            {
                englishTwo.Total = englishTwo.SBA + englishTwo.Final;
                if (englishTwo.Total >= 80)
                    englishTwo.GPA = 4.00;
                else if (englishTwo.Total >= 75 && englishTwo.Total < 80)
                    englishTwo.GPA = 3.75;
                else if (englishTwo.Total >= 70 && englishTwo.Total < 75)
                    englishTwo.GPA = 3.50;
                else if (englishTwo.Total >= 65 && englishTwo.Total < 70)
                    englishTwo.GPA = 3.25;
                else if (englishTwo.Total >= 60 && englishTwo.Total < 65)
                    englishTwo.GPA = 3.00;
                else if (englishTwo.Total >= 55 && englishTwo.Total < 60)
                    englishTwo.GPA = 2.75;
                else if (englishTwo.Total >= 50 && englishTwo.Total < 55)
                    englishTwo.GPA = 2.50;
                else if (englishTwo.Total >= 45 && englishTwo.Total < 50)
                    englishTwo.GPA = 2.25;
                else if (englishTwo.Total >= 40 && englishTwo.Total < 45)
                    englishTwo.GPA = 2.00;
                else if (englishTwo.Total < 40)
                    englishTwo.GPA = 0.00;

                if (englishTwo.Total >= 80)
                    englishTwo.Grade = "A+";
                else if (englishTwo.Total >= 75 && englishTwo.Total < 80)
                    englishTwo.Grade = "A";
                else if (englishTwo.Total >= 70 && englishTwo.Total < 75)
                    englishTwo.Grade = "A-";
                else if (englishTwo.Total >= 65 && englishTwo.Total < 70)
                    englishTwo.Grade = "B+";
                else if (englishTwo.Total >= 60 && englishTwo.Total < 65)
                    englishTwo.Grade = "B";
                else if (englishTwo.Total >= 55 && englishTwo.Total < 60)
                    englishTwo.Grade = "B-";
                else if (englishTwo.Total >= 50 && englishTwo.Total < 55)
                    englishTwo.Grade = "C+";
                else if (englishTwo.Total >= 45 && englishTwo.Total < 50)
                    englishTwo.Grade = "C";
                else if (englishTwo.Total >= 40 && englishTwo.Total < 45)
                    englishTwo.Grade = "D";
                else if (englishTwo.Total < 40)
                    englishTwo.Grade = "F";
                db.EnglishTwo.Add(englishTwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwo);
        }

        // GET: EnglishTwo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwo englishTwo = db.EnglishTwo.Find(id);
            if (englishTwo == null)
            {
                return HttpNotFound();
            }
            return View(englishTwo);
        }

        // POST: EnglishTwo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwo englishTwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwo);
        }

        // GET: EnglishTwo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwo englishTwo = db.EnglishTwo.Find(id);
            if (englishTwo == null)
            {
                return HttpNotFound();
            }
            return View(englishTwo);
        }

        // POST: EnglishTwo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwo englishTwo = db.EnglishTwo.Find(id);
            db.EnglishTwo.Remove(englishTwo);
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
