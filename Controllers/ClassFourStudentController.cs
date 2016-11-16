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
    public class ClassFourStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassFourStudent
        public ActionResult Index()
        {
            return View(db.ClassFourStudents.ToList());
        }

        // GET: ClassFourStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFourStudent classFourStudent = db.ClassFourStudents.Find(id);
            if (classFourStudent == null)
            {
                return HttpNotFound();
            }
            return View(classFourStudent);
        }

        // GET: ClassFourStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassFourStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassFourStudent classFourStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassFourStudents.Add(classFourStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classFourStudent);
        }

        // GET: ClassFourStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFourStudent classFourStudent = db.ClassFourStudents.Find(id);
            if (classFourStudent == null)
            {
                return HttpNotFound();
            }
            return View(classFourStudent);
        }

        // POST: ClassFourStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassFourStudent classFourStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classFourStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classFourStudent);
        }

        // GET: ClassFourStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFourStudent classFourStudent = db.ClassFourStudents.Find(id);
            if (classFourStudent == null)
            {
                return HttpNotFound();
            }
            return View(classFourStudent);
        }

        // POST: ClassFourStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassFourStudent classFourStudent = db.ClassFourStudents.Find(id);
            db.ClassFourStudents.Remove(classFourStudent);
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
