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
    public class EnglishTwoTenController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwoTen
        public ActionResult Index()
        {
            return View(db.EnglishTwoTens.ToList());
        }

        // GET: EnglishTwoTen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoTen englishTwoTen = db.EnglishTwoTens.Find(id);
            if (englishTwoTen == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoTen);
        }

        // GET: EnglishTwoTen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwoTen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoTen englishTwoTen)
        {
            if (ModelState.IsValid)
            {
                englishTwoTen.Total = englishTwoTen.SBA + englishTwoTen.Final;
                if (englishTwoTen.Total >= 80)
                    englishTwoTen.GPA = 4.00;
                else if (englishTwoTen.Total >= 75 && englishTwoTen.Total < 80)
                    englishTwoTen.GPA = 3.75;
                else if (englishTwoTen.Total >= 70 && englishTwoTen.Total < 75)
                    englishTwoTen.GPA = 3.50;
                else if (englishTwoTen.Total >= 65 && englishTwoTen.Total < 70)
                    englishTwoTen.GPA = 3.25;
                else if (englishTwoTen.Total >= 60 && englishTwoTen.Total < 65)
                    englishTwoTen.GPA = 3.00;
                else if (englishTwoTen.Total >= 55 && englishTwoTen.Total < 60)
                    englishTwoTen.GPA = 2.75;
                else if (englishTwoTen.Total >= 50 && englishTwoTen.Total < 55)
                    englishTwoTen.GPA = 2.50;
                else if (englishTwoTen.Total >= 45 && englishTwoTen.Total < 50)
                    englishTwoTen.GPA = 2.25;
                else if (englishTwoTen.Total >= 40 && englishTwoTen.Total < 45)
                    englishTwoTen.GPA = 2.00;
                else if (englishTwoTen.Total < 40)
                    englishTwoTen.GPA = 0.00;

                if (englishTwoTen.Total >= 80)
                    englishTwoTen.Grade = "A+";
                else if (englishTwoTen.Total >= 75 && englishTwoTen.Total < 80)
                    englishTwoTen.Grade = "A";
                else if (englishTwoTen.Total >= 70 && englishTwoTen.Total < 75)
                    englishTwoTen.Grade = "A-";
                else if (englishTwoTen.Total >= 65 && englishTwoTen.Total < 70)
                    englishTwoTen.Grade = "B+";
                else if (englishTwoTen.Total >= 60 && englishTwoTen.Total < 65)
                    englishTwoTen.Grade = "B";
                else if (englishTwoTen.Total >= 55 && englishTwoTen.Total < 60)
                    englishTwoTen.Grade = "B-";
                else if (englishTwoTen.Total >= 50 && englishTwoTen.Total < 55)
                    englishTwoTen.Grade = "C+";
                else if (englishTwoTen.Total >= 45 && englishTwoTen.Total < 50)
                    englishTwoTen.Grade = "C";
                else if (englishTwoTen.Total >= 40 && englishTwoTen.Total < 45)
                    englishTwoTen.Grade = "D";
                else if (englishTwoTen.Total < 40)
                    englishTwoTen.Grade = "F";
                db.EnglishTwoTens.Add(englishTwoTen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwoTen);
        }

        // GET: EnglishTwoTen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoTen englishTwoTen = db.EnglishTwoTens.Find(id);
            if (englishTwoTen == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoTen);
        }

        // POST: EnglishTwoTen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoTen englishTwoTen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwoTen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwoTen);
        }

        // GET: EnglishTwoTen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoTen englishTwoTen = db.EnglishTwoTens.Find(id);
            if (englishTwoTen == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoTen);
        }

        // POST: EnglishTwoTen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwoTen englishTwoTen = db.EnglishTwoTens.Find(id);
            db.EnglishTwoTens.Remove(englishTwoTen);
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
