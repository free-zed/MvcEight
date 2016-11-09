using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEight.Models
{
    public class Exam
    {
        public int ID { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamSubject { get; set; }
        public string ExamSyllabus { get; set; }
    }
}