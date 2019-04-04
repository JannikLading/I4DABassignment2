using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardReplacement.Models
{
    public class Calendar
    {
        [Key]
        public string CalendarId { get; set; }
        public  string Lecture { get; set; }
        public DateTime Date { get; set; }
        public DateTime Deadline { get; set; }
    }
}
