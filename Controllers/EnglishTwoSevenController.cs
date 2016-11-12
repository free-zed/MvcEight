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
    public class EnglishTwoSevenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwoSeven
        public ActionResult Index()
        {
            return View(db.EnglishTwoSevens.ToList());
        }

        // GET: EnglishTwoSeven/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoSeven englishTwoSeven = db.EnglishTwoSevens.Find(id);
            if (englishTwoSeven == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoSeven);
        }

        // GET: EnglishTwoSeven/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwoSeven/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoSeven englishTwoSeven)
        {
            if (ModelState.IsValid)
            {
                englishTwoSeven.Total = englishTwoSeven.SBA + englishTwoSeven.Final;
                if (englishTwoSeven.Total >= 80)
                    englishTwoSeven.GPA = 4.00;
                else if (englishTwoSeven.Total >= 75 && englishTwoSeven.Total < 80)
                    englishTwoSeven.GPA = 3.75;
                else if (englishTwoSeven.Total >= 70 && englishTwoSeven.Total < 75)
                    englishTwoSeven.GPA = 3.50;
                else if (englishTwoSeven.Total >= 65 && englishTwoSeven.Total < 70)
                    englishTwoSeven.GPA = 3.25;
                else if (englishTwoSeven.Total >= 60 && englishTwoSeven.Total < 65)
                    englishTwoSeven.GPA = 3.00;
                else if (englishTwoSeven.Total >= 55 && englishTwoSeven.Total < 60)
                    englishTwoSeven.GPA = 2.75;
                else if (englishTwoSeven.Total >= 50 && englishTwoSeven.Total < 55)
                    englishTwoSeven.GPA = 2.50;
                else if (englishTwoSeven.Total >= 45 && englishTwoSeven.Total < 50)
                    englishTwoSeven.GPA = 2.25;
                else if (englishTwoSeven.Total >= 40 && englishTwoSeven.Total < 45)
                    englishTwoSeven.GPA = 2.00;
                else if (englishTwoSeven.Total < 40)
                    englishTwoSeven.GPA = 0.00;

                if (englishTwoSeven.Total >= 80)
                    englishTwoSeven.Grade = "A+";
                else if (englishTwoSeven.Total >= 75 && englishTwoSeven.Total < 80)
                    englishTwoSeven.Grade = "A";
                else if (englishTwoSeven.Total >= 70 && englishTwoSeven.Total < 75)
                    englishTwoSeven.Grade = "A-";
                else if (englishTwoSeven.Total >= 65 && englishTwoSeven.Total < 70)
                    englishTwoSeven.Grade = "B+";
                else if (englishTwoSeven.Total >= 60 && englishTwoSeven.Total < 65)
                    englishTwoSeven.Grade = "B";
                else if (englishTwoSeven.Total >= 55 && englishTwoSeven.Total < 60)
                    englishTwoSeven.Grade = "B-";
                else if (englishTwoSeven.Total >= 50 && englishTwoSeven.Total < 55)
                    englishTwoSeven.Grade = "C+";
                else if (englishTwoSeven.Total >= 45 && englishTwoSeven.Total < 50)
                    englishTwoSeven.Grade = "C";
                else if (englishTwoSeven.Total >= 40 && englishTwoSeven.Total < 45)
                    englishTwoSeven.Grade = "D";
                else if (englishTwoSeven.Total < 40)
                    englishTwoSeven.Grade = "F";
                db.EnglishTwoSevens.Add(englishTwoSeven);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwoSeven);
        }

        // GET: EnglishTwoSeven/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoSeven englishTwoSeven = db.EnglishTwoSevens.Find(id);
            if (englishTwoSeven == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoSeven);
        }

        // POST: EnglishTwoSeven/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoSeven englishTwoSeven)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwoSeven).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwoSeven);
        }

        // GET: EnglishTwoSeven/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoSeven englishTwoSeven = db.EnglishTwoSevens.Find(id);
            if (englishTwoSeven == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoSeven);
        }

        // POST: EnglishTwoSeven/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwoSeven englishTwoSeven = db.EnglishTwoSevens.Find(id);
            db.EnglishTwoSevens.Remove(englishTwoSeven);
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
