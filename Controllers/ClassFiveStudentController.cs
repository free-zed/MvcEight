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
    public class ClassFiveStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassFiveStudent
        public ActionResult Index()
        {
            return View(db.ClassFiveStudents.ToList());
        }

        // GET: ClassFiveStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFiveStudent classFiveStudent = db.ClassFiveStudents.Find(id);
            if (classFiveStudent == null)
            {
                return HttpNotFound();
            }
            return View(classFiveStudent);
        }

        // GET: ClassFiveStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassFiveStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassFiveStudent classFiveStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassFiveStudents.Add(classFiveStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classFiveStudent);
        }

        // GET: ClassFiveStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFiveStudent classFiveStudent = db.ClassFiveStudents.Find(id);
            if (classFiveStudent == null)
            {
                return HttpNotFound();
            }
            return View(classFiveStudent);
        }

        // POST: ClassFiveStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassFiveStudent classFiveStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classFiveStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classFiveStudent);
        }

        // GET: ClassFiveStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassFiveStudent classFiveStudent = db.ClassFiveStudents.Find(id);
            if (classFiveStudent == null)
            {
                return HttpNotFound();
            }
            return View(classFiveStudent);
        }

        // POST: ClassFiveStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassFiveStudent classFiveStudent = db.ClassFiveStudents.Find(id);
            db.ClassFiveStudents.Remove(classFiveStudent);
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
