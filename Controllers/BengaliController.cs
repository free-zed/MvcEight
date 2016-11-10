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
    public class BengaliController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Bengali
        public ActionResult Index()
        {
            return View(db.Bengalis.ToList());
        }

        // GET: Bengali/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bengali bengali = db.Bengalis.Find(id);
            if (bengali == null)
            {
                return HttpNotFound();
            }
            return View(bengali);
        }

        // GET: Bengali/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bengali/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] Bengali bengali)
        {
            if (ModelState.IsValid)
            {
                bengali.Total = bengali.SBA + bengali.Final;
                if (bengali.Total >= 80)
                    bengali.GPA = 4.00;
                else if (bengali.Total >= 75 && bengali.Total < 80)
                    bengali.GPA = 3.75;
                else if (bengali.Total >= 70 && bengali.Total < 75)
                    bengali.GPA = 3.50;
                else if (bengali.Total >= 65 && bengali.Total < 70)
                    bengali.GPA = 3.25;
                else if (bengali.Total >= 60 && bengali.Total < 65)
                    bengali.GPA = 3.00;
                else if (bengali.Total >= 55 && bengali.Total < 60)
                    bengali.GPA = 2.75;
                else if (bengali.Total >= 50 && bengali.Total < 55)
                    bengali.GPA = 2.50;
                else if (bengali.Total >= 45 && bengali.Total < 50)
                    bengali.GPA = 2.25;
                else if (bengali.Total >= 40 && bengali.Total < 45)
                    bengali.GPA = 2.00;
                else if (bengali.Total < 40)
                    bengali.GPA = 0.00;

                if (bengali.Total >= 80)
                    bengali.Grade = "A+";
                else if (bengali.Total >= 75 && bengali.Total < 80)
                    bengali.Grade = "A";
                else if (bengali.Total >= 70 && bengali.Total < 75)
                    bengali.Grade = "A-";
                else if (bengali.Total >= 65 && bengali.Total < 70)
                    bengali.Grade = "B+";
                else if (bengali.Total >= 60 && bengali.Total < 65)
                    bengali.Grade = "B";
                else if (bengali.Total >= 55 && bengali.Total < 60)
                    bengali.Grade = "B-";
                else if (bengali.Total >= 50 && bengali.Total < 55)
                    bengali.Grade = "C+";
                else if (bengali.Total >= 45 && bengali.Total < 50)
                    bengali.Grade = "C";
                else if (bengali.Total >= 40 && bengali.Total < 45)
                    bengali.Grade = "D";
                else if (bengali.Total < 40)
                    bengali.Grade = "F";
                db.Bengalis.Add(bengali);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bengali);
        }

        // GET: Bengali/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bengali bengali = db.Bengalis.Find(id);
            if (bengali == null)
            {
                return HttpNotFound();
            }
            return View(bengali);
        }

        // POST: Bengali/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] Bengali bengali)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bengali).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bengali);
        }

        // GET: Bengali/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bengali bengali = db.Bengalis.Find(id);
            if (bengali == null)
            {
                return HttpNotFound();
            }
            return View(bengali);
        }

        // POST: Bengali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bengali bengali = db.Bengalis.Find(id);
            db.Bengalis.Remove(bengali);
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
