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
    public class AllTheCourseController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: AllTheCourse
        public ActionResult Index()
        {
            return View(db.AllTheCourses.ToList());
        }

        // GET: AllTheCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheCourse allTheCourse = db.AllTheCourses.Find(id);
            if (allTheCourse == null)
            {
                return HttpNotFound();
            }
            return View(allTheCourse);
        }

        // GET: AllTheCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllTheCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseName,CourseTeacher,CourseOfClass,Division")] AllTheCourse allTheCourse)
        {
            if (ModelState.IsValid)
            {
                db.AllTheCourses.Add(allTheCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTheCourse);
        }

        // GET: AllTheCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheCourse allTheCourse = db.AllTheCourses.Find(id);
            if (allTheCourse == null)
            {
                return HttpNotFound();
            }
            return View(allTheCourse);
        }

        // POST: AllTheCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseName,CourseTeacher,CourseOfClass,Division")] AllTheCourse allTheCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allTheCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allTheCourse);
        }

        // GET: AllTheCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheCourse allTheCourse = db.AllTheCourses.Find(id);
            if (allTheCourse == null)
            {
                return HttpNotFound();
            }
            return View(allTheCourse);
        }

        // POST: AllTheCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllTheCourse allTheCourse = db.AllTheCourses.Find(id);
            db.AllTheCourses.Remove(allTheCourse);
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

        public ActionResult ClassOneCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("One"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassTwoCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Two"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassThreeCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Three"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassFourCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Four"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassFiveCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Five"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassSixCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Six"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassSevenCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Seven"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassEightCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Eight"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassNineCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Nine"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }

        public ActionResult ClassTenCourse()
        {
            IQueryable<AllTheCourse> AllTheCourses = db.AllTheCourses
               .Where(c => c.CourseOfClass.Equals("Ten"));
            var sql = AllTheCourses.ToString();
            return View(AllTheCourses.ToList());
        }
    }
}
