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
    public class ClassTwoStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassTwoStudent
        public ActionResult Index()
        {
            return View(db.ClassTwoStudents.ToList());
        }

        // GET: ClassTwoStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTwoStudent classTwoStudent = db.ClassTwoStudents.Find(id);
            if (classTwoStudent == null)
            {
                return HttpNotFound();
            }
            return View(classTwoStudent);
        }

        // GET: ClassTwoStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassTwoStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassTwoStudent classTwoStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassTwoStudents.Add(classTwoStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classTwoStudent);
        }

        // GET: ClassTwoStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTwoStudent classTwoStudent = db.ClassTwoStudents.Find(id);
            if (classTwoStudent == null)
            {
                return HttpNotFound();
            }
            return View(classTwoStudent);
        }

        // POST: ClassTwoStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassTwoStudent classTwoStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTwoStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classTwoStudent);
        }

        // GET: ClassTwoStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTwoStudent classTwoStudent = db.ClassTwoStudents.Find(id);
            if (classTwoStudent == null)
            {
                return HttpNotFound();
            }
            return View(classTwoStudent);
        }

        // POST: ClassTwoStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassTwoStudent classTwoStudent = db.ClassTwoStudents.Find(id);
            db.ClassTwoStudents.Remove(classTwoStudent);
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
