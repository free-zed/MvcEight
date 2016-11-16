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
    public class ClassOneStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassOneStudent
        public ActionResult Index()
        {
            return View(db.ClassOneStudents.ToList());
        }

        // GET: ClassOneStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOneStudent classOneStudent = db.ClassOneStudents.Find(id);
            if (classOneStudent == null)
            {
                return HttpNotFound();
            }
            return View(classOneStudent);
        }

        // GET: ClassOneStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassOneStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassOneStudent classOneStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassOneStudents.Add(classOneStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classOneStudent);
        }

        // GET: ClassOneStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOneStudent classOneStudent = db.ClassOneStudents.Find(id);
            if (classOneStudent == null)
            {
                return HttpNotFound();
            }
            return View(classOneStudent);
        }

        // POST: ClassOneStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassOneStudent classOneStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classOneStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classOneStudent);
        }

        // GET: ClassOneStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassOneStudent classOneStudent = db.ClassOneStudents.Find(id);
            if (classOneStudent == null)
            {
                return HttpNotFound();
            }
            return View(classOneStudent);
        }

        // POST: ClassOneStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassOneStudent classOneStudent = db.ClassOneStudents.Find(id);
            db.ClassOneStudents.Remove(classOneStudent);
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
