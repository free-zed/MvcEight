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
    public class ClassTenStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassTenStudent
        public ActionResult Index()
        {
            return View(db.ClassTenStudents.ToList());
        }

        // GET: ClassTenStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTenStudent classTenStudent = db.ClassTenStudents.Find(id);
            if (classTenStudent == null)
            {
                return HttpNotFound();
            }
            return View(classTenStudent);
        }

        // GET: ClassTenStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassTenStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassTenStudent classTenStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassTenStudents.Add(classTenStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classTenStudent);
        }

        // GET: ClassTenStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTenStudent classTenStudent = db.ClassTenStudents.Find(id);
            if (classTenStudent == null)
            {
                return HttpNotFound();
            }
            return View(classTenStudent);
        }

        // POST: ClassTenStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassTenStudent classTenStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTenStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classTenStudent);
        }

        // GET: ClassTenStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTenStudent classTenStudent = db.ClassTenStudents.Find(id);
            if (classTenStudent == null)
            {
                return HttpNotFound();
            }
            return View(classTenStudent);
        }

        // POST: ClassTenStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassTenStudent classTenStudent = db.ClassTenStudents.Find(id);
            db.ClassTenStudents.Remove(classTenStudent);
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
