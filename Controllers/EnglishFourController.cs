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
    public class EnglishFourController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishFour
        public ActionResult Index()
        {
            return View(db.EnglishFours.ToList());
        }

        // GET: EnglishFour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishFour englishFour = db.EnglishFours.Find(id);
            if (englishFour == null)
            {
                return HttpNotFound();
            }
            return View(englishFour);
        }

        // GET: EnglishFour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishFour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishFour englishFour)
        {
            if (ModelState.IsValid)
            {
                englishFour.Total = englishFour.SBA + englishFour.Final;
                if (englishFour.Total >= 80)
                    englishFour.GPA = 4.00;
                else if (englishFour.Total >= 75 && englishFour.Total < 80)
                    englishFour.GPA = 3.75;
                else if (englishFour.Total >= 70 && englishFour.Total < 75)
                    englishFour.GPA = 3.50;
                else if (englishFour.Total >= 65 && englishFour.Total < 70)
                    englishFour.GPA = 3.25;
                else if (englishFour.Total >= 60 && englishFour.Total < 65)
                    englishFour.GPA = 3.00;
                else if (englishFour.Total >= 55 && englishFour.Total < 60)
                    englishFour.GPA = 2.75;
                else if (englishFour.Total >= 50 && englishFour.Total < 55)
                    englishFour.GPA = 2.50;
                else if (englishFour.Total >= 45 && englishFour.Total < 50)
                    englishFour.GPA = 2.25;
                else if (englishFour.Total >= 40 && englishFour.Total < 45)
                    englishFour.GPA = 2.00;
                else if (englishFour.Total < 40)
                    englishFour.GPA = 0.00;

                if (englishFour.Total >= 80)
                    englishFour.Grade = "A+";
                else if (englishFour.Total >= 75 && englishFour.Total < 80)
                    englishFour.Grade = "A";
                else if (englishFour.Total >= 70 && englishFour.Total < 75)
                    englishFour.Grade = "A-";
                else if (englishFour.Total >= 65 && englishFour.Total < 70)
                    englishFour.Grade = "B+";
                else if (englishFour.Total >= 60 && englishFour.Total < 65)
                    englishFour.Grade = "B";
                else if (englishFour.Total >= 55 && englishFour.Total < 60)
                    englishFour.Grade = "B-";
                else if (englishFour.Total >= 50 && englishFour.Total < 55)
                    englishFour.Grade = "C+";
                else if (englishFour.Total >= 45 && englishFour.Total < 50)
                    englishFour.Grade = "C";
                else if (englishFour.Total >= 40 && englishFour.Total < 45)
                    englishFour.Grade = "D";
                else if (englishFour.Total < 40)
                    englishFour.Grade = "F";
                db.EnglishFours.Add(englishFour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishFour);
        }

        // GET: EnglishFour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishFour englishFour = db.EnglishFours.Find(id);
            if (englishFour == null)
            {
                return HttpNotFound();
            }
            return View(englishFour);
        }

        // POST: EnglishFour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishFour englishFour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishFour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishFour);
        }

        // GET: EnglishFour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishFour englishFour = db.EnglishFours.Find(id);
            if (englishFour == null)
            {
                return HttpNotFound();
            }
            return View(englishFour);
        }

        // POST: EnglishFour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishFour englishFour = db.EnglishFours.Find(id);
            db.EnglishFours.Remove(englishFour);
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
