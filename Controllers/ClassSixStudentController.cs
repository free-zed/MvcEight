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
    public class ClassSixStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassSixStudent
        public ActionResult Index()
        {
            return View(db.ClassSixStudents.ToList());
        }

        // GET: ClassSixStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSixStudent classSixStudent = db.ClassSixStudents.Find(id);
            if (classSixStudent == null)
            {
                return HttpNotFound();
            }
            return View(classSixStudent);
        }

        // GET: ClassSixStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassSixStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassSixStudent classSixStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassSixStudents.Add(classSixStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classSixStudent);
        }

        // GET: ClassSixStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSixStudent classSixStudent = db.ClassSixStudents.Find(id);
            if (classSixStudent == null)
            {
                return HttpNotFound();
            }
            return View(classSixStudent);
        }

        // POST: ClassSixStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassSixStudent classSixStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSixStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classSixStudent);
        }

        // GET: ClassSixStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSixStudent classSixStudent = db.ClassSixStudents.Find(id);
            if (classSixStudent == null)
            {
                return HttpNotFound();
            }
            return View(classSixStudent);
        }

        // POST: ClassSixStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSixStudent classSixStudent = db.ClassSixStudents.Find(id);
            db.ClassSixStudents.Remove(classSixStudent);
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
