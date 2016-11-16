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
    public class ClassNineStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassNineStudent
        public ActionResult Index()
        {
            return View(db.ClassNineStudents.ToList());
        }

        // GET: ClassNineStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassNineStudent classNineStudent = db.ClassNineStudents.Find(id);
            if (classNineStudent == null)
            {
                return HttpNotFound();
            }
            return View(classNineStudent);
        }

        // GET: ClassNineStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassNineStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassNineStudent classNineStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassNineStudents.Add(classNineStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classNineStudent);
        }

        // GET: ClassNineStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassNineStudent classNineStudent = db.ClassNineStudents.Find(id);
            if (classNineStudent == null)
            {
                return HttpNotFound();
            }
            return View(classNineStudent);
        }

        // POST: ClassNineStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassNineStudent classNineStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classNineStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classNineStudent);
        }

        // GET: ClassNineStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassNineStudent classNineStudent = db.ClassNineStudents.Find(id);
            if (classNineStudent == null)
            {
                return HttpNotFound();
            }
            return View(classNineStudent);
        }

        // POST: ClassNineStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassNineStudent classNineStudent = db.ClassNineStudents.Find(id);
            db.ClassNineStudents.Remove(classNineStudent);
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
