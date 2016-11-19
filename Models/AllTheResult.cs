using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEight.Models
{
    public class AllTheResult
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string NameOfClass { get; set; }
        public string Subject { get; set; }
        public string Roll { get; set; }
        public string Name { get; set; }
        public double SBA { get; set; }
        public double Final { get; set; }
        public double Total { get; set; }
        public double GPA { get; set; }
        public string Grade { get; set; }
    }
}