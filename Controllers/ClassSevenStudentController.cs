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
    public class ClassSevenStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ClassSevenStudent
        public ActionResult Index()
        {
            return View(db.ClassSevenStudents.ToList());
        }

        // GET: ClassSevenStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSevenStudent classSevenStudent = db.ClassSevenStudents.Find(id);
            if (classSevenStudent == null)
            {
                return HttpNotFound();
            }
            return View(classSevenStudent);
        }

        // GET: ClassSevenStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassSevenStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassSevenStudent classSevenStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassSevenStudents.Add(classSevenStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classSevenStudent);
        }

        // GET: ClassSevenStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSevenStudent classSevenStudent = db.ClassSevenStudents.Find(id);
            if (classSevenStudent == null)
            {
                return HttpNotFound();
            }
            return View(classSevenStudent);
        }

        // POST: ClassSevenStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,Name,Email,Cell")] ClassSevenStudent classSevenStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSevenStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classSevenStudent);
        }

        // GET: ClassSevenStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSevenStudent classSevenStudent = db.ClassSevenStudents.Find(id);
            if (classSevenStudent == null)
            {
                return HttpNotFound();
            }
            return View(classSevenStudent);
        }

        // POST: ClassSevenStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSevenStudent classSevenStudent = db.ClassSevenStudents.Find(id);
            db.ClassSevenStudents.Remove(classSevenStudent);
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
