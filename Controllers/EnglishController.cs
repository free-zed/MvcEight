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
    public class EnglishController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: English
        public ActionResult Index()
        {
            return View(db.Englishs.ToList());
        }

        // GET: English/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English english = db.Englishs.Find(id);
            if (english == null)
            {
                return HttpNotFound();
            }
            return View(english);
        }

        // GET: English/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: English/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] English english)
        {
                if (ModelState.IsValid)
                {
                    english.Total = english.SBA + english.Final;
                    if (english.Total >= 80)
                        english.GPA = 4.00;
                    else if (english.Total >= 75 && english.Total < 80)
                        english.GPA = 3.75;
                    else if (english.Total >= 70 && english.Total < 75)
                        english.GPA = 3.50;
                    else if (english.Total >= 65 && english.Total < 70)
                        english.GPA = 3.25;
                    else if (english.Total >= 60 && english.Total < 65)
                        english.GPA = 3.00;
                    else if (english.Total >= 55 && english.Total < 60)
                        english.GPA = 2.75;
                    else if (english.Total >= 50 && english.Total < 55)
                        english.GPA = 2.50;
                    else if (english.Total >= 45 && english.Total < 50)
                        english.GPA = 2.25;
                    else if (english.Total >= 40 && english.Total < 45)
                        english.GPA = 2.00;
                    else if (english.Total < 40)
                        english.GPA = 0.00;

                    if (english.Total >= 80)
                        english.Grade = "A+";
                    else if (english.Total >= 75 && english.Total < 80)
                        english.Grade = "A";
                    else if (english.Total >= 70 && english.Total < 75)
                        english.Grade = "A-";
                    else if (english.Total >= 65 && english.Total < 70)
                        english.Grade = "B+";
                    else if (english.Total >= 60 && english.Total < 65)
                        english.Grade = "B";
                    else if (english.Total >= 55 && english.Total < 60)
                        english.Grade = "B-";
                    else if (english.Total >= 50 && english.Total < 55)
                        english.Grade = "C+";
                    else if (english.Total >= 45 && english.Total < 50)
                        english.Grade = "C";
                    else if (english.Total >= 40 && english.Total < 45)
                        english.Grade = "D";
                    else if (english.Total < 40)
                        english.Grade = "F";

                    db.Englishs.Add(english);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }

            return View(english);
        }

        // GET: English/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English english = db.Englishs.Find(id);
            if (english == null)
            {
                return HttpNotFound();
            }
            return View(english);
        }

        // POST: English/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] English english)
        {
            if (ModelState.IsValid)
            {
                db.Entry(english).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(english);
        }

        // GET: English/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English english = db.Englishs.Find(id);
            if (english == null)
            {
                return HttpNotFound();
            }
            return View(english);
        }

        // POST: English/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            English english = db.Englishs.Find(id);
            db.Englishs.Remove(english);
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
