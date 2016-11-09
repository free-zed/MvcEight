using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEight.Models
{
    public class Holiday
    {
        public int ID { get; set; }
        public string VacationFor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ClassResumesOn { get; set; }
    }
}