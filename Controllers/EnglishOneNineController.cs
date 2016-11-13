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
    public class EnglishOneNineController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishOneNine
        public ActionResult Index()
        {
            return View(db.EnglishOneNines.ToList());
        }

        // GET: EnglishOneNine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneNine englishOneNine = db.EnglishOneNines.Find(id);
            if (englishOneNine == null)
            {
                return HttpNotFound();
            }
            return View(englishOneNine);
        }

        // GET: EnglishOneNine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishOneNine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneNine englishOneNine)
        {
            if (ModelState.IsValid)
            {
                englishOneNine.Total = englishOneNine.SBA + englishOneNine.Final;
                if (englishOneNine.Total >= 80)
                    englishOneNine.GPA = 4.00;
                else if (englishOneNine.Total >= 75 && englishOneNine.Total < 80)
                    englishOneNine.GPA = 3.75;
                else if (englishOneNine.Total >= 70 && englishOneNine.Total < 75)
                    englishOneNine.GPA = 3.50;
                else if (englishOneNine.Total >= 65 && englishOneNine.Total < 70)
                    englishOneNine.GPA = 3.25;
                else if (englishOneNine.Total >= 60 && englishOneNine.Total < 65)
                    englishOneNine.GPA = 3.00;
                else if (englishOneNine.Total >= 55 && englishOneNine.Total < 60)
                    englishOneNine.GPA = 2.75;
                else if (englishOneNine.Total >= 50 && englishOneNine.Total < 55)
                    englishOneNine.GPA = 2.50;
                else if (englishOneNine.Total >= 45 && englishOneNine.Total < 50)
                    englishOneNine.GPA = 2.25;
                else if (englishOneNine.Total >= 40 && englishOneNine.Total < 45)
                    englishOneNine.GPA = 2.00;
                else if (englishOneNine.Total < 40)
                    englishOneNine.GPA = 0.00;

                if (englishOneNine.Total >= 80)
                    englishOneNine.Grade = "A+";
                else if (englishOneNine.Total >= 75 && englishOneNine.Total < 80)
                    englishOneNine.Grade = "A";
                else if (englishOneNine.Total >= 70 && englishOneNine.Total < 75)
                    englishOneNine.Grade = "A-";
                else if (englishOneNine.Total >= 65 && englishOneNine.Total < 70)
                    englishOneNine.Grade = "B+";
                else if (englishOneNine.Total >= 60 && englishOneNine.Total < 65)
                    englishOneNine.Grade = "B";
                else if (englishOneNine.Total >= 55 && englishOneNine.Total < 60)
                    englishOneNine.Grade = "B-";
                else if (englishOneNine.Total >= 50 && englishOneNine.Total < 55)
                    englishOneNine.Grade = "C+";
                else if (englishOneNine.Total >= 45 && englishOneNine.Total < 50)
                    englishOneNine.Grade = "C";
                else if (englishOneNine.Total >= 40 && englishOneNine.Total < 45)
                    englishOneNine.Grade = "D";
                else if (englishOneNine.Total < 40)
                    englishOneNine.Grade = "F";
                db.EnglishOneNines.Add(englishOneNine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishOneNine);
        }

        // GET: EnglishOneNine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneNine englishOneNine = db.EnglishOneNines.Find(id);
            if (englishOneNine == null)
            {
                return HttpNotFound();
            }
            return View(englishOneNine);
        }

        // POST: EnglishOneNine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneNine englishOneNine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishOneNine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishOneNine);
        }

        // GET: EnglishOneNine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneNine englishOneNine = db.EnglishOneNines.Find(id);
            if (englishOneNine == null)
            {
                return HttpNotFound();
            }
            return View(englishOneNine);
        }

        // POST: EnglishOneNine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishOneNine englishOneNine = db.EnglishOneNines.Find(id);
            db.EnglishOneNines.Remove(englishOneNine);
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
