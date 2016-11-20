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
    public class AllTheResultController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: AllTheResult
        public ActionResult Index()
        {
            return View(db.AllTheResults.ToList());
        }

        // GET: AllTheResult/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheResult allTheResult = db.AllTheResults.Find(id);
            if (allTheResult == null)
            {
                return HttpNotFound();
            }
            return View(allTheResult);
        }

        // GET: AllTheResult/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllTheResult/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year,NameOfClass,Subject,Roll,Name,SBA,Final,Total,GPA,Grade")] AllTheResult allTheResult)
        {
            /*if (ModelState.IsValid)
            {
                db.AllTheResults.Add(allTheResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTheResult);*/
            if (ModelState.IsValid)
            {
                allTheResult.Total = allTheResult.SBA + allTheResult.Final;
                if (allTheResult.Total >= 80)
                    allTheResult.GPA = 4.00;
                else if (allTheResult.Total >= 75 && allTheResult.Total < 80)
                    allTheResult.GPA = 3.75;
                else if (allTheResult.Total >= 70 && allTheResult.Total < 75)
                    allTheResult.GPA = 3.50;
                else if (allTheResult.Total >= 65 && allTheResult.Total < 70)
                    allTheResult.GPA = 3.25;
                else if (allTheResult.Total >= 60 && allTheResult.Total < 65)
                    allTheResult.GPA = 3.00;
                else if (allTheResult.Total >= 55 && allTheResult.Total < 60)
                    allTheResult.GPA = 2.75;
                else if (allTheResult.Total >= 50 && allTheResult.Total < 55)
                    allTheResult.GPA = 2.50;
                else if (allTheResult.Total >= 45 && allTheResult.Total < 50)
                    allTheResult.GPA = 2.25;
                else if (allTheResult.Total >= 40 && allTheResult.Total < 45)
                    allTheResult.GPA = 2.00;
                else if (allTheResult.Total < 40)
                    allTheResult.GPA = 0.00;

                if (allTheResult.Total >= 80)
                    allTheResult.Grade = "A+";
                else if (allTheResult.Total >= 75 && allTheResult.Total < 80)
                    allTheResult.Grade = "A";
                else if (allTheResult.Total >= 70 && allTheResult.Total < 75)
                    allTheResult.Grade = "A-";
                else if (allTheResult.Total >= 65 && allTheResult.Total < 70)
                    allTheResult.Grade = "B+";
                else if (allTheResult.Total >= 60 && allTheResult.Total < 65)
                    allTheResult.Grade = "B";
                else if (allTheResult.Total >= 55 && allTheResult.Total < 60)
                    allTheResult.Grade = "B-";
                else if (allTheResult.Total >= 50 && allTheResult.Total < 55)
                    allTheResult.Grade = "C+";
                else if (allTheResult.Total >= 45 && allTheResult.Total < 50)
                    allTheResult.Grade = "C";
                else if (allTheResult.Total >= 40 && allTheResult.Total < 45)
                    allTheResult.Grade = "D";
                else if (allTheResult.Total < 40)
                    allTheResult.Grade = "F";
                db.AllTheResults.Add(allTheResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTheResult);
        }

        // GET: AllTheResult/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheResult allTheResult = db.AllTheResults.Find(id);
            if (allTheResult == null)
            {
                return HttpNotFound();
            }
            return View(allTheResult);
        }

        // POST: AllTheResult/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year,NameOfClass,Subject,Roll,Name,SBA,Final,Total,GPA,Grade")] AllTheResult allTheResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allTheResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allTheResult);
        }

        // GET: AllTheResult/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheResult allTheResult = db.AllTheResults.Find(id);
            if (allTheResult == null)
            {
                return HttpNotFound();
            }
            return View(allTheResult);
        }

        // POST: AllTheResult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllTheResult allTheResult = db.AllTheResults.Find(id);
            db.AllTheResults.Remove(allTheResult);
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

        //Result of Class One
        public ActionResult ReClassOneResult()
        {
            return View();
        }

        public ActionResult ClassOneBengali()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("One") &&  c.Subject.Equals("Bengali"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassOneEnglish()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("One") && c.Subject.Equals("English"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassOneMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("One") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        //Result of Class Two
        public ActionResult ReClassTwoResult()
        {
            return View();
        }

        public ActionResult ClassTwoBengali()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Two") && c.Subject.Equals("Bengali"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTwoEnglish()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Two") && c.Subject.Equals("English"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTwoMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Two") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        //Result of Class Three
        public ActionResult ReClassThreeResult()
        {
            return View();
        }

        public ActionResult ClassThreeBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Three") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassThreeBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Three") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassThreeEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Three") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassThreeEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Three") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassThreeMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Three") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassThreeScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Three") && c.Subject.Equals("Science"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }



        //Result of Class Four
        public ActionResult ReClassFourResult()
        {
            return View();
        }

        public ActionResult ClassFourBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("Science"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFourReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Four") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }


        //Result of Class Five
        public ActionResult ReClassFiveResult()
        {
            return View();
        }

        public ActionResult ClassFiveBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("Science"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassFiveReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Five") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }


        //Result of Class Six
        public ActionResult ReClassSixResult()
        {
            return View();
        }

        public ActionResult ClassSixBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("Science"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSixReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Six") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }


        //Result of Class Seven
        public ActionResult ReClassSevenResult()
        {
            return View();
        }

        public ActionResult ClassSevenBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("Science"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassSevenReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Seven") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        //Result of Class Eight
        public ActionResult ReClassEightResult()
        {
            return View();
        }

        public ActionResult ClassEightBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("Mathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("Science"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassEightReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Eight") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }


        //Result of Class Nine
        public ActionResult ReClassNineResult()
        {
            return View();
        }

        public ActionResult ClassNineBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineGeneralMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("GeneralMathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineHigherMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("HigherMathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNinePhysics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("Physics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineChemistry()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("Chemistry"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineBiology()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("Biology"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassNineReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Nine") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        //Result of Class Ten
        public ActionResult ReClassTenResult()
        {
            return View();
        }

        public ActionResult ClassTenBengaliOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("BengaliOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenBengaliTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("BengaliTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenEnglishOne()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("EnglishOne"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenEnglishTwo()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("EnglishTwo"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenGeneralMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("GeneralMathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenHigherMathematics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("HigherMathematics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenPhysics()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("Physics"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenChemistry()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("Chemistry"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenBiology()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("Biology"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenSocialScience()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("SocialScience"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }

        public ActionResult ClassTenReligion()
        {

            IQueryable<AllTheResult> AllTheResults = db.AllTheResults
            .Where(c => c.NameOfClass.Equals("Ten") && c.Subject.Equals("Religion"));
            var sql = AllTheResults.ToString();
            return View(AllTheResults.ToList());

        }
    }
}
