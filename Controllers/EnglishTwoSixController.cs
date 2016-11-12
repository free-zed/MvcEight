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
    public class EnglishTwoSixController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishTwoSix
        public ActionResult Index()
        {
            return View(db.EnglishTwoSixs.ToList());
        }

        // GET: EnglishTwoSix/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoSix englishTwoSix = db.EnglishTwoSixs.Find(id);
            if (englishTwoSix == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoSix);
        }

        // GET: EnglishTwoSix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishTwoSix/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoSix englishTwoSix)
        {
            if (ModelState.IsValid)
            {
                englishTwoSix.Total = englishTwoSix.SBA + englishTwoSix.Final;
                if (englishTwoSix.Total >= 80)
                    englishTwoSix.GPA = 4.00;
                else if (englishTwoSix.Total >= 75 && englishTwoSix.Total < 80)
                    englishTwoSix.GPA = 3.75;
                else if (englishTwoSix.Total >= 70 && englishTwoSix.Total < 75)
                    englishTwoSix.GPA = 3.50;
                else if (englishTwoSix.Total >= 65 && englishTwoSix.Total < 70)
                    englishTwoSix.GPA = 3.25;
                else if (englishTwoSix.Total >= 60 && englishTwoSix.Total < 65)
                    englishTwoSix.GPA = 3.00;
                else if (englishTwoSix.Total >= 55 && englishTwoSix.Total < 60)
                    englishTwoSix.GPA = 2.75;
                else if (englishTwoSix.Total >= 50 && englishTwoSix.Total < 55)
                    englishTwoSix.GPA = 2.50;
                else if (englishTwoSix.Total >= 45 && englishTwoSix.Total < 50)
                    englishTwoSix.GPA = 2.25;
                else if (englishTwoSix.Total >= 40 && englishTwoSix.Total < 45)
                    englishTwoSix.GPA = 2.00;
                else if (englishTwoSix.Total < 40)
                    englishTwoSix.GPA = 0.00;

                if (englishTwoSix.Total >= 80)
                    englishTwoSix.Grade = "A+";
                else if (englishTwoSix.Total >= 75 && englishTwoSix.Total < 80)
                    englishTwoSix.Grade = "A";
                else if (englishTwoSix.Total >= 70 && englishTwoSix.Total < 75)
                    englishTwoSix.Grade = "A-";
                else if (englishTwoSix.Total >= 65 && englishTwoSix.Total < 70)
                    englishTwoSix.Grade = "B+";
                else if (englishTwoSix.Total >= 60 && englishTwoSix.Total < 65)
                    englishTwoSix.Grade = "B";
                else if (englishTwoSix.Total >= 55 && englishTwoSix.Total < 60)
                    englishTwoSix.Grade = "B-";
                else if (englishTwoSix.Total >= 50 && englishTwoSix.Total < 55)
                    englishTwoSix.Grade = "C+";
                else if (englishTwoSix.Total >= 45 && englishTwoSix.Total < 50)
                    englishTwoSix.Grade = "C";
                else if (englishTwoSix.Total >= 40 && englishTwoSix.Total < 45)
                    englishTwoSix.Grade = "D";
                else if (englishTwoSix.Total < 40)
                    englishTwoSix.Grade = "F";
                db.EnglishTwoSixs.Add(englishTwoSix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishTwoSix);
        }

        // GET: EnglishTwoSix/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoSix englishTwoSix = db.EnglishTwoSixs.Find(id);
            if (englishTwoSix == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoSix);
        }

        // POST: EnglishTwoSix/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishTwoSix englishTwoSix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishTwoSix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishTwoSix);
        }

        // GET: EnglishTwoSix/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishTwoSix englishTwoSix = db.EnglishTwoSixs.Find(id);
            if (englishTwoSix == null)
            {
                return HttpNotFound();
            }
            return View(englishTwoSix);
        }

        // POST: EnglishTwoSix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishTwoSix englishTwoSix = db.EnglishTwoSixs.Find(id);
            db.EnglishTwoSixs.Remove(englishTwoSix);
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
