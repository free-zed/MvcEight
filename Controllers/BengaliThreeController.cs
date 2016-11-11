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
    public class BengaliThreeController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliThree
        public ActionResult Index()
        {
            return View(db.BengaliThree.ToList());
        }

        // GET: BengaliThree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliThree bengaliThree = db.BengaliThree.Find(id);
            if (bengaliThree == null)
            {
                return HttpNotFound();
            }
            return View(bengaliThree);
        }

        // GET: BengaliThree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliThree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliThree bengaliThree)
        {
            if (ModelState.IsValid)
            {
                bengaliThree.Total = bengaliThree.SBA + bengaliThree.Final;
                if (bengaliThree.Total >= 80)
                    bengaliThree.GPA = 4.00;
                else if (bengaliThree.Total >= 75 && bengaliThree.Total < 80)
                    bengaliThree.GPA = 3.75;
                else if (bengaliThree.Total >= 70 && bengaliThree.Total < 75)
                    bengaliThree.GPA = 3.50;
                else if (bengaliThree.Total >= 65 && bengaliThree.Total < 70)
                    bengaliThree.GPA = 3.25;
                else if (bengaliThree.Total >= 60 && bengaliThree.Total < 65)
                    bengaliThree.GPA = 3.00;
                else if (bengaliThree.Total >= 55 && bengaliThree.Total < 60)
                    bengaliThree.GPA = 2.75;
                else if (bengaliThree.Total >= 50 && bengaliThree.Total < 55)
                    bengaliThree.GPA = 2.50;
                else if (bengaliThree.Total >= 45 && bengaliThree.Total < 50)
                    bengaliThree.GPA = 2.25;
                else if (bengaliThree.Total >= 40 && bengaliThree.Total < 45)
                    bengaliThree.GPA = 2.00;
                else if (bengaliThree.Total < 40)
                    bengaliThree.GPA = 0.00;

                if (bengaliThree.Total >= 80)
                    bengaliThree.Grade = "A+";
                else if (bengaliThree.Total >= 75 && bengaliThree.Total < 80)
                    bengaliThree.Grade = "A";
                else if (bengaliThree.Total >= 70 && bengaliThree.Total < 75)
                    bengaliThree.Grade = "A-";
                else if (bengaliThree.Total >= 65 && bengaliThree.Total < 70)
                    bengaliThree.Grade = "B+";
                else if (bengaliThree.Total >= 60 && bengaliThree.Total < 65)
                    bengaliThree.Grade = "B";
                else if (bengaliThree.Total >= 55 && bengaliThree.Total < 60)
                    bengaliThree.Grade = "B-";
                else if (bengaliThree.Total >= 50 && bengaliThree.Total < 55)
                    bengaliThree.Grade = "C+";
                else if (bengaliThree.Total >= 45 && bengaliThree.Total < 50)
                    bengaliThree.Grade = "C";
                else if (bengaliThree.Total >= 40 && bengaliThree.Total < 45)
                    bengaliThree.Grade = "D";
                else if (bengaliThree.Total < 40)
                    bengaliThree.Grade = "F";
                db.BengaliThree.Add(bengaliThree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliThree);
        }

        // GET: BengaliThree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliThree bengaliThree = db.BengaliThree.Find(id);
            if (bengaliThree == null)
            {
                return HttpNotFound();
            }
            return View(bengaliThree);
        }

        // POST: BengaliThree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliThree bengaliThree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliThree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliThree);
        }

        // GET: BengaliThree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliThree bengaliThree = db.BengaliThree.Find(id);
            if (bengaliThree == null)
            {
                return HttpNotFound();
            }
            return View(bengaliThree);
        }

        // POST: BengaliThree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliThree bengaliThree = db.BengaliThree.Find(id);
            db.BengaliThree.Remove(bengaliThree);
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
