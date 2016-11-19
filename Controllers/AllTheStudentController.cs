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
    public class AllTheStudentController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: AllTheStudent
        public ActionResult Index()
        {
            return View(db.AllTheStudents.ToList());
        }

        // GET: AllTheStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheStudent allTheStudent = db.AllTheStudents.Find(id);
            if (allTheStudent == null)
            {
                return HttpNotFound();
            }
            return View(allTheStudent);
        }

        // GET: AllTheStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllTheStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year,NameOfClass,Roll,Name,Email,Cell")] AllTheStudent allTheStudent)
        {
            if (ModelState.IsValid)
            {
                db.AllTheStudents.Add(allTheStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTheStudent);
        }

        // GET: AllTheStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheStudent allTheStudent = db.AllTheStudents.Find(id);
            if (allTheStudent == null)
            {
                return HttpNotFound();
            }
            return View(allTheStudent);
        }

        // POST: AllTheStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year,NameOfClass,Roll,Name,Email,Cell")] AllTheStudent allTheStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allTheStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allTheStudent);
        }

        // GET: AllTheStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheStudent allTheStudent = db.AllTheStudents.Find(id);
            if (allTheStudent == null)
            {
                return HttpNotFound();
            }
            return View(allTheStudent);
        }

        // POST: AllTheStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllTheStudent allTheStudent = db.AllTheStudents.Find(id);
            db.AllTheStudents.Remove(allTheStudent);
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

        public ActionResult ReClassOneStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("One"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }
        public ActionResult ReClassTwoStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Two"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassThreeStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Three"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassFourStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Four"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassFiveStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Five"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassSixStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Six"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassSevenStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Seven"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassEightStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Eight"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassNineStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Nine"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }

        public ActionResult ReClassTenStudent()
        {


            IQueryable<AllTheStudent> AllTheStudents = db.AllTheStudents
            .Where(c => c.NameOfClass.Equals("Ten"));
            var sql = AllTheStudents.ToString();
            return View(AllTheStudents.ToList());

        }
    }
}
