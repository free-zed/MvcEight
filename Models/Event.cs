using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEight.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventPlace { get; set; }
        public string EventDetails { get; set; }
    }
}