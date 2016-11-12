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
    public class EnglishOneSevenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishOneSeven
        public ActionResult Index()
        {
            return View(db.EnglishOneSevens.ToList());
        }

        // GET: EnglishOneSeven/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneSeven englishOneSeven = db.EnglishOneSevens.Find(id);
            if (englishOneSeven == null)
            {
                return HttpNotFound();
            }
            return View(englishOneSeven);
        }

        // GET: EnglishOneSeven/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishOneSeven/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneSeven englishOneSeven)
        {
            if (ModelState.IsValid)
            {
                englishOneSeven.Total = englishOneSeven.SBA + englishOneSeven.Final;
                if (englishOneSeven.Total >= 80)
                    englishOneSeven.GPA = 4.00;
                else if (englishOneSeven.Total >= 75 && englishOneSeven.Total < 80)
                    englishOneSeven.GPA = 3.75;
                else if (englishOneSeven.Total >= 70 && englishOneSeven.Total < 75)
                    englishOneSeven.GPA = 3.50;
                else if (englishOneSeven.Total >= 65 && englishOneSeven.Total < 70)
                    englishOneSeven.GPA = 3.25;
                else if (englishOneSeven.Total >= 60 && englishOneSeven.Total < 65)
                    englishOneSeven.GPA = 3.00;
                else if (englishOneSeven.Total >= 55 && englishOneSeven.Total < 60)
                    englishOneSeven.GPA = 2.75;
                else if (englishOneSeven.Total >= 50 && englishOneSeven.Total < 55)
                    englishOneSeven.GPA = 2.50;
                else if (englishOneSeven.Total >= 45 && englishOneSeven.Total < 50)
                    englishOneSeven.GPA = 2.25;
                else if (englishOneSeven.Total >= 40 && englishOneSeven.Total < 45)
                    englishOneSeven.GPA = 2.00;
                else if (englishOneSeven.Total < 40)
                    englishOneSeven.GPA = 0.00;

                if (englishOneSeven.Total >= 80)
                    englishOneSeven.Grade = "A+";
                else if (englishOneSeven.Total >= 75 && englishOneSeven.Total < 80)
                    englishOneSeven.Grade = "A";
                else if (englishOneSeven.Total >= 70 && englishOneSeven.Total < 75)
                    englishOneSeven.Grade = "A-";
                else if (englishOneSeven.Total >= 65 && englishOneSeven.Total < 70)
                    englishOneSeven.Grade = "B+";
                else if (englishOneSeven.Total >= 60 && englishOneSeven.Total < 65)
                    englishOneSeven.Grade = "B";
                else if (englishOneSeven.Total >= 55 && englishOneSeven.Total < 60)
                    englishOneSeven.Grade = "B-";
                else if (englishOneSeven.Total >= 50 && englishOneSeven.Total < 55)
                    englishOneSeven.Grade = "C+";
                else if (englishOneSeven.Total >= 45 && englishOneSeven.Total < 50)
                    englishOneSeven.Grade = "C";
                else if (englishOneSeven.Total >= 40 && englishOneSeven.Total < 45)
                    englishOneSeven.Grade = "D";
                else if (englishOneSeven.Total < 40)
                    englishOneSeven.Grade = "F";
                db.EnglishOneSevens.Add(englishOneSeven);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishOneSeven);
        }

        // GET: EnglishOneSeven/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneSeven englishOneSeven = db.EnglishOneSevens.Find(id);
            if (englishOneSeven == null)
            {
                return HttpNotFound();
            }
            return View(englishOneSeven);
        }

        // POST: EnglishOneSeven/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneSeven englishOneSeven)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishOneSeven).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishOneSeven);
        }

        // GET: EnglishOneSeven/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneSeven englishOneSeven = db.EnglishOneSevens.Find(id);
            if (englishOneSeven == null)
            {
                return HttpNotFound();
            }
            return View(englishOneSeven);
        }

        // POST: EnglishOneSeven/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishOneSeven englishOneSeven = db.EnglishOneSevens.Find(id);
            db.EnglishOneSevens.Remove(englishOneSeven);
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
