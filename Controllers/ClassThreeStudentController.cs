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
    public class ClassThreeStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassThreeStudent
        public ActionResult Index()
        {
            return View(db.ClassThreeStudents.ToList());
        }

        // GET: ClassThreeStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassThreeStudent classThreeStudent = db.ClassThreeStudents.Find(id);
            if (classThreeStudent == null)
            {
                return HttpNotFound();
            }
            return View(classThreeStudent);
        }

        // GET: ClassThreeStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassThreeStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassThreeStudent classThreeStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassThreeStudents.Add(classThreeStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classThreeStudent);
        }

        // GET: ClassThreeStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassThreeStudent classThreeStudent = db.ClassThreeStudents.Find(id);
            if (classThreeStudent == null)
            {
                return HttpNotFound();
            }
            return View(classThreeStudent);
        }

        // POST: ClassThreeStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassThreeStudent classThreeStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classThreeStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classThreeStudent);
        }

        // GET: ClassThreeStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassThreeStudent classThreeStudent = db.ClassThreeStudents.Find(id);
            if (classThreeStudent == null)
            {
                return HttpNotFound();
            }
            return View(classThreeStudent);
        }

        // POST: ClassThreeStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassThreeStudent classThreeStudent = db.ClassThreeStudents.Find(id);
            db.ClassThreeStudents.Remove(classThreeStudent);
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
