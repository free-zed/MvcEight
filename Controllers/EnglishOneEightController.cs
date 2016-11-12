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
    public class EnglishOneEightController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishOneEight
        public ActionResult Index()
        {
            return View(db.EnglishOneEights.ToList());
        }

        // GET: EnglishOneEight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneEight englishOneEight = db.EnglishOneEights.Find(id);
            if (englishOneEight == null)
            {
                return HttpNotFound();
            }
            return View(englishOneEight);
        }

        // GET: EnglishOneEight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishOneEight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneEight englishOneEight)
        {
            if (ModelState.IsValid)
            {
                englishOneEight.Total = englishOneEight.SBA + englishOneEight.Final;
                if (englishOneEight.Total >= 80)
                    englishOneEight.GPA = 4.00;
                else if (englishOneEight.Total >= 75 && englishOneEight.Total < 80)
                    englishOneEight.GPA = 3.75;
                else if (englishOneEight.Total >= 70 && englishOneEight.Total < 75)
                    englishOneEight.GPA = 3.50;
                else if (englishOneEight.Total >= 65 && englishOneEight.Total < 70)
                    englishOneEight.GPA = 3.25;
                else if (englishOneEight.Total >= 60 && englishOneEight.Total < 65)
                    englishOneEight.GPA = 3.00;
                else if (englishOneEight.Total >= 55 && englishOneEight.Total < 60)
                    englishOneEight.GPA = 2.75;
                else if (englishOneEight.Total >= 50 && englishOneEight.Total < 55)
                    englishOneEight.GPA = 2.50;
                else if (englishOneEight.Total >= 45 && englishOneEight.Total < 50)
                    englishOneEight.GPA = 2.25;
                else if (englishOneEight.Total >= 40 && englishOneEight.Total < 45)
                    englishOneEight.GPA = 2.00;
                else if (englishOneEight.Total < 40)
                    englishOneEight.GPA = 0.00;

                if (englishOneEight.Total >= 80)
                    englishOneEight.Grade = "A+";
                else if (englishOneEight.Total >= 75 && englishOneEight.Total < 80)
                    englishOneEight.Grade = "A";
                else if (englishOneEight.Total >= 70 && englishOneEight.Total < 75)
                    englishOneEight.Grade = "A-";
                else if (englishOneEight.Total >= 65 && englishOneEight.Total < 70)
                    englishOneEight.Grade = "B+";
                else if (englishOneEight.Total >= 60 && englishOneEight.Total < 65)
                    englishOneEight.Grade = "B";
                else if (englishOneEight.Total >= 55 && englishOneEight.Total < 60)
                    englishOneEight.Grade = "B-";
                else if (englishOneEight.Total >= 50 && englishOneEight.Total < 55)
                    englishOneEight.Grade = "C+";
                else if (englishOneEight.Total >= 45 && englishOneEight.Total < 50)
                    englishOneEight.Grade = "C";
                else if (englishOneEight.Total >= 40 && englishOneEight.Total < 45)
                    englishOneEight.Grade = "D";
                else if (englishOneEight.Total < 40)
                    englishOneEight.Grade = "F";
                db.EnglishOneEights.Add(englishOneEight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishOneEight);
        }

        // GET: EnglishOneEight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneEight englishOneEight = db.EnglishOneEights.Find(id);
            if (englishOneEight == null)
            {
                return HttpNotFound();
            }
            return View(englishOneEight);
        }

        // POST: EnglishOneEight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishOneEight englishOneEight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishOneEight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishOneEight);
        }

        // GET: EnglishOneEight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishOneEight englishOneEight = db.EnglishOneEights.Find(id);
            if (englishOneEight == null)
            {
                return HttpNotFound();
            }
            return View(englishOneEight);
        }

        // POST: EnglishOneEight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishOneEight englishOneEight = db.EnglishOneEights.Find(id);
            db.EnglishOneEights.Remove(englishOneEight);
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
