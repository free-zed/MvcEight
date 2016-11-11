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
    public class BengaliFourController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: BengaliFour
        public ActionResult Index()
        {
            return View(db.BengaliFours.ToList());
        }

        // GET: BengaliFour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliFour bengaliFour = db.BengaliFours.Find(id);
            if (bengaliFour == null)
            {
                return HttpNotFound();
            }
            return View(bengaliFour);
        }

        // GET: BengaliFour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BengaliFour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliFour bengaliFour)
        {
            if (ModelState.IsValid)
            {
                bengaliFour.Total = bengaliFour.SBA + bengaliFour.Final;
                if (bengaliFour.Total >= 80)
                    bengaliFour.GPA = 4.00;
                else if (bengaliFour.Total >= 75 && bengaliFour.Total < 80)
                    bengaliFour.GPA = 3.75;
                else if (bengaliFour.Total >= 70 && bengaliFour.Total < 75)
                    bengaliFour.GPA = 3.50;
                else if (bengaliFour.Total >= 65 && bengaliFour.Total < 70)
                    bengaliFour.GPA = 3.25;
                else if (bengaliFour.Total >= 60 && bengaliFour.Total < 65)
                    bengaliFour.GPA = 3.00;
                else if (bengaliFour.Total >= 55 && bengaliFour.Total < 60)
                    bengaliFour.GPA = 2.75;
                else if (bengaliFour.Total >= 50 && bengaliFour.Total < 55)
                    bengaliFour.GPA = 2.50;
                else if (bengaliFour.Total >= 45 && bengaliFour.Total < 50)
                    bengaliFour.GPA = 2.25;
                else if (bengaliFour.Total >= 40 && bengaliFour.Total < 45)
                    bengaliFour.GPA = 2.00;
                else if (bengaliFour.Total < 40)
                    bengaliFour.GPA = 0.00;

                if (bengaliFour.Total >= 80)
                    bengaliFour.Grade = "A+";
                else if (bengaliFour.Total >= 75 && bengaliFour.Total < 80)
                    bengaliFour.Grade = "A";
                else if (bengaliFour.Total >= 70 && bengaliFour.Total < 75)
                    bengaliFour.Grade = "A-";
                else if (bengaliFour.Total >= 65 && bengaliFour.Total < 70)
                    bengaliFour.Grade = "B+";
                else if (bengaliFour.Total >= 60 && bengaliFour.Total < 65)
                    bengaliFour.Grade = "B";
                else if (bengaliFour.Total >= 55 && bengaliFour.Total < 60)
                    bengaliFour.Grade = "B-";
                else if (bengaliFour.Total >= 50 && bengaliFour.Total < 55)
                    bengaliFour.Grade = "C+";
                else if (bengaliFour.Total >= 45 && bengaliFour.Total < 50)
                    bengaliFour.Grade = "C";
                else if (bengaliFour.Total >= 40 && bengaliFour.Total < 45)
                    bengaliFour.Grade = "D";
                else if (bengaliFour.Total < 40)
                    bengaliFour.Grade = "F";
                db.BengaliFours.Add(bengaliFour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengaliFour);
        }

        // GET: BengaliFour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliFour bengaliFour = db.BengaliFours.Find(id);
            if (bengaliFour == null)
            {
                return HttpNotFound();
            }
            return View(bengaliFour);
        }

        // POST: BengaliFour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] BengaliFour bengaliFour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengaliFour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengaliFour);
        }

        // GET: BengaliFour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BengaliFour bengaliFour = db.BengaliFours.Find(id);
            if (bengaliFour == null)
            {
                return HttpNotFound();
            }
            return View(bengaliFour);
        }

        // POST: BengaliFour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BengaliFour bengaliFour = db.BengaliFours.Find(id);
            db.BengaliFours.Remove(bengaliFour);
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
