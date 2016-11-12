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
    public class EnglishTwoEightController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwoEight
        public ActionResult Index()
        {
            return View(db.EnglishTwoEights.ToList());
        }

        // GET: EnglishTwoEight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoEight englishTwoEight = db.EnglishTwoEights.Find(id);
            if (englishTwoEight == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoEight);
        }

        // GET: EnglishTwoEight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwoEight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoEight englishTwoEight)
        {
            if (ModelState.IsValid)
            {
                englishTwoEight.Total = englishTwoEight.SBA + englishTwoEight.Final;
                if (englishTwoEight.Total >= 80)
                    englishTwoEight.GPA = 4.00;
                else if (englishTwoEight.Total >= 75 && englishTwoEight.Total < 80)
                    englishTwoEight.GPA = 3.75;
                else if (englishTwoEight.Total >= 70 && englishTwoEight.Total < 75)
                    englishTwoEight.GPA = 3.50;
                else if (englishTwoEight.Total >= 65 && englishTwoEight.Total < 70)
                    englishTwoEight.GPA = 3.25;
                else if (englishTwoEight.Total >= 60 && englishTwoEight.Total < 65)
                    englishTwoEight.GPA = 3.00;
                else if (englishTwoEight.Total >= 55 && englishTwoEight.Total < 60)
                    englishTwoEight.GPA = 2.75;
                else if (englishTwoEight.Total >= 50 && englishTwoEight.Total < 55)
                    englishTwoEight.GPA = 2.50;
                else if (englishTwoEight.Total >= 45 && englishTwoEight.Total < 50)
                    englishTwoEight.GPA = 2.25;
                else if (englishTwoEight.Total >= 40 && englishTwoEight.Total < 45)
                    englishTwoEight.GPA = 2.00;
                else if (englishTwoEight.Total < 40)
                    englishTwoEight.GPA = 0.00;

                if (englishTwoEight.Total >= 80)
                    englishTwoEight.Grade = "A+";
                else if (englishTwoEight.Total >= 75 && englishTwoEight.Total < 80)
                    englishTwoEight.Grade = "A";
                else if (englishTwoEight.Total >= 70 && englishTwoEight.Total < 75)
                    englishTwoEight.Grade = "A-";
                else if (englishTwoEight.Total >= 65 && englishTwoEight.Total < 70)
                    englishTwoEight.Grade = "B+";
                else if (englishTwoEight.Total >= 60 && englishTwoEight.Total < 65)
                    englishTwoEight.Grade = "B";
                else if (englishTwoEight.Total >= 55 && englishTwoEight.Total < 60)
                    englishTwoEight.Grade = "B-";
                else if (englishTwoEight.Total >= 50 && englishTwoEight.Total < 55)
                    englishTwoEight.Grade = "C+";
                else if (englishTwoEight.Total >= 45 && englishTwoEight.Total < 50)
                    englishTwoEight.Grade = "C";
                else if (englishTwoEight.Total >= 40 && englishTwoEight.Total < 45)
                    englishTwoEight.Grade = "D";
                else if (englishTwoEight.Total < 40)
                    englishTwoEight.Grade = "F";
                db.EnglishTwoEights.Add(englishTwoEight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwoEight);
        }

        // GET: EnglishTwoEight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoEight englishTwoEight = db.EnglishTwoEights.Find(id);
            if (englishTwoEight == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoEight);
        }

        // POST: EnglishTwoEight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoEight englishTwoEight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwoEight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwoEight);
        }

        // GET: EnglishTwoEight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoEight englishTwoEight = db.EnglishTwoEights.Find(id);
            if (englishTwoEight == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoEight);
        }

        // POST: EnglishTwoEight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwoEight englishTwoEight = db.EnglishTwoEights.Find(id);
            db.EnglishTwoEights.Remove(englishTwoEight);
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
