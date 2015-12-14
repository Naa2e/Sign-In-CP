using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Lesson
    {
        public int LessonId { get; }
        public int AcceptedPayType { get; set; }
        public int ClassType { get; set; }
        public int NumOfPayments { get; set; }
        public string Title { get; set; }
        public enum DayOfWeek { } 

        public virtual List<Student> Class { get; set; }
        public virtual List<Payment> Revenue { get; set; }
        public virtual Teacher Instructor { get; set; }

        public Lesson()
        {
            Class = new List<Student>();
            Revenue = new List<Payment>();
            Instructor = new Teacher();
        }
    }
}