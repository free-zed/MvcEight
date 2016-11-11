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
    public class EnglishThreeController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: EnglishThree
        public ActionResult Index()
        {
            return View(db.EnglishThree.ToList());
        }

        // GET: EnglishThree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishThree englishThree = db.EnglishThree.Find(id);
            if (englishThree == null)
            {
                return HttpNotFound();
            }
            return View(englishThree);
        }

        // GET: EnglishThree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnglishThree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishThree englishThree)
        {
            if (ModelState.IsValid)
            {
                englishThree.Total = englishThree.SBA + englishThree.Final;
                if (englishThree.Total >= 80)
                    englishThree.GPA = 4.00;
                else if (englishThree.Total >= 75 && englishThree.Total < 80)
                    englishThree.GPA = 3.75;
                else if (englishThree.Total >= 70 && englishThree.Total < 75)
                    englishThree.GPA = 3.50;
                else if (englishThree.Total >= 65 && englishThree.Total < 70)
                    englishThree.GPA = 3.25;
                else if (englishThree.Total >= 60 && englishThree.Total < 65)
                    englishThree.GPA = 3.00;
                else if (englishThree.Total >= 55 && englishThree.Total < 60)
                    englishThree.GPA = 2.75;
                else if (englishThree.Total >= 50 && englishThree.Total < 55)
                    englishThree.GPA = 2.50;
                else if (englishThree.Total >= 45 && englishThree.Total < 50)
                    englishThree.GPA = 2.25;
                else if (englishThree.Total >= 40 && englishThree.Total < 45)
                    englishThree.GPA = 2.00;
                else if (englishThree.Total < 40)
                    englishThree.GPA = 0.00;

                if (englishThree.Total >= 80)
                    englishThree.Grade = "A+";
                else if (englishThree.Total >= 75 && englishThree.Total < 80)
                    englishThree.Grade = "A";
                else if (englishThree.Total >= 70 && englishThree.Total < 75)
                    englishThree.Grade = "A-";
                else if (englishThree.Total >= 65 && englishThree.Total < 70)
                    englishThree.Grade = "B+";
                else if (englishThree.Total >= 60 && englishThree.Total < 65)
                    englishThree.Grade = "B";
                else if (englishThree.Total >= 55 && englishThree.Total < 60)
                    englishThree.Grade = "B-";
                else if (englishThree.Total >= 50 && englishThree.Total < 55)
                    englishThree.Grade = "C+";
                else if (englishThree.Total >= 45 && englishThree.Total < 50)
                    englishThree.Grade = "C";
                else if (englishThree.Total >= 40 && englishThree.Total < 45)
                    englishThree.Grade = "D";
                else if (englishThree.Total < 40)
                    englishThree.Grade = "F";
                db.EnglishThree.Add(englishThree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(englishThree);
        }

        // GET: EnglishThree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishThree englishThree = db.EnglishThree.Find(id);
            if (englishThree == null)
            {
                return HttpNotFound();
            }
            return View(englishThree);
        }

        // POST: EnglishThree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] EnglishThree englishThree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(englishThree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(englishThree);
        }

        // GET: EnglishThree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnglishThree englishThree = db.EnglishThree.Find(id);
            if (englishThree == null)
            {
                return HttpNotFound();
            }
            return View(englishThree);
        }

        // POST: EnglishThree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnglishThree englishThree = db.EnglishThree.Find(id);
            db.EnglishThree.Remove(englishThree);
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
