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
    public class AllTheTeacherController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: AllTheTeacher
        public ActionResult Index()
        {
            return View(db.AllTheTeachers.ToList());
        }

        // GET: AllTheTeacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            if (allTheTeacher == null)
            {
                return HttpNotFound();
            }
            return View(allTheTeacher);
        }

        // GET: AllTheTeacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllTheTeacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Cell,NameOfClass,Subject")] AllTheTeacher allTheTeacher)
        {
            if (ModelState.IsValid)
            {
                db.AllTheTeachers.Add(allTheTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTheTeacher);
        }

        // GET: AllTheTeacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            if (allTheTeacher == null)
            {
                return HttpNotFound();
            }
            return View(allTheTeacher);
        }

        // POST: AllTheTeacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Cell,NameOfClass,Subject")] AllTheTeacher allTheTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allTheTeacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allTheTeacher);
        }

        // GET: AllTheTeacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            if (allTheTeacher == null)
            {
                return HttpNotFound();
            }
            return View(allTheTeacher);
        }

        // POST: AllTheTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            db.AllTheTeachers.Remove(allTheTeacher);
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

        public ActionResult ClassOneTeacher()
        {


            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
            .Where(c => c.NameOfClass.Equals("One"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());

        }

        public ActionResult ClassTwoTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
                .Where(c => c.NameOfClass.Equals("Two"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassThreeTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Three"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassFourTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Four"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassFiveTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Five"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassSixTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Six"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassSevenTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Seven"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassEightTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Eight"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassNineTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Nine"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }

        public ActionResult ClassTenTeacher()
        {
            IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
               .Where(c => c.NameOfClass.Equals("Ten"));
            var sql = AllTheTeachers.ToString();
            return View(AllTheTeachers.ToList());
        }
    }
}
