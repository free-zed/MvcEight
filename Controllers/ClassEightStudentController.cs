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
    public class ClassEightStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassEightStudent
        public ActionResult Index()
        {
            return View(db.ClassEightStudents.ToList());
        }

        // GET: ClassEightStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassEightStudent classEightStudent = db.ClassEightStudents.Find(id);
            if (classEightStudent == null)
            {
                return HttpNotFound();
            }
            return View(classEightStudent);
        }

        // GET: ClassEightStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassEightStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassEightStudent classEightStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassEightStudents.Add(classEightStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classEightStudent);
        }

        // GET: ClassEightStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassEightStudent classEightStudent = db.ClassEightStudents.Find(id);
            if (classEightStudent == null)
            {
                return HttpNotFound();
            }
            return View(classEightStudent);
        }

        // POST: ClassEightStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassEightStudent classEightStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classEightStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classEightStudent);
        }

        // GET: ClassEightStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassEightStudent classEightStudent = db.ClassEightStudents.Find(id);
            if (classEightStudent == null)
            {
                return HttpNotFound();
            }
            return View(classEightStudent);
        }

        // POST: ClassEightStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassEightStudent classEightStudent = db.ClassEightStudents.Find(id);
            db.ClassEightStudents.Remove(classEightStudent);
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
