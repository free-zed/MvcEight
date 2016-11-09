using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcEight.Models;

namespace MvcEight.DAL
{
    public class ExamInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ExamContext>
    {
        protected override void Seed(ExamContext context)
        {
            var exams = new List<Exam>
            {
            new Exam {ExamDate=DateTime.Parse("2016-11-30"),ExamSubject="Physics",ExamSyllabus="Chapter12"},
                    new Exam {ExamDate = DateTime.Parse("2016-12-02"),ExamSubject ="Chemistry",ExamSyllabus="Chapter12"},
                    new Exam {ExamDate=DateTime.Parse("2016-12-05"),ExamSubject="Maths",ExamSyllabus="Chapter12"},
                    new Exam {ExamDate=DateTime.Parse("2016-12-08"),ExamSubject="Biology",ExamSyllabus="Chapter12"},
                     new Exam {ExamDate=DateTime.Parse("2016-11-30"),ExamSubject="Physics",ExamSyllabus="Chapter12"},
                    new Exam {ExamDate = DateTime.Parse("2016-12-02"),ExamSubject ="Chemistry",ExamSyllabus="Chapter12"},
                    new Exam {ExamDate=DateTime.Parse("2016-12-05"),ExamSubject="Maths",ExamSyllabus="Chapter12"},
                    new Exam {ExamDate=DateTime.Parse("2016-12-08"),ExamSubject="Biology",ExamSyllabus="Chapter12"}
            };

            exams.ForEach(s => context.Exams.Add(s));
            context.SaveChanges();

            var holidays = new List<Holiday>
                {

                    new Holiday {VacationFor="Eid-ul-Adha",StartDate=DateTime.Parse("2016-11-30"),EndDate=DateTime.Parse("2016-11-30"),ClassResumesOn=DateTime.Parse("2016-11-30")},
                    new Holiday {VacationFor="Eid-ul-Fitr",StartDate=DateTime.Parse("2016-11-30"),EndDate=DateTime.Parse("2016-11-30"),ClassResumesOn=DateTime.Parse("2016-11-30")},
                    new Holiday {VacationFor="Maths",StartDate=DateTime.Parse("2016-11-30"),EndDate=DateTime.Parse("2016-11-30"),ClassResumesOn=DateTime.Parse("2016-11-30")},
                    new Holiday {VacationFor="Biology",StartDate=DateTime.Parse("2016-11-30"),EndDate=DateTime.Parse("2016-11-30"),ClassResumesOn=DateTime.Parse("2016-11-30")},
                     new Holiday {VacationFor="Eid-ul-Adha",StartDate=DateTime.Parse("2016-11-30"),EndDate=DateTime.Parse("2016-11-30"),ClassResumesOn=DateTime.Parse("2016-11-30")},
                    new Holiday {VacationFor="Eid-ul-Fitr",StartDate=DateTime.Parse("2016-11-30"),EndDate=DateTime.Parse("2016-11-30"),ClassResumesOn=DateTime.Parse("2016-11-30")}
                };
            holidays.ForEach(s => context.Holidays.Add(s));
            context.SaveChanges();

            var events = new List<Event>
                {

                    new Event {EventName="Eid-ul-Adha",EventDate=DateTime.Parse("2016-11-30"),EventPlace="Eid-ul-Adha",EventDetails="Eid-ul-Adha"},
                    new Event {EventName="Eid-ul-Fitr",EventDate=DateTime.Parse("2016-11-30"),EventPlace="Eid-ul-Adha",EventDetails="Eid-ul-Adha"},
                };
            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();
        }
    }
}