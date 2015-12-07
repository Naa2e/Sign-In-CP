using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Lesson
    {
        public int PayType { get; set; }
        public int ClassType { get; set; }
        public string Instructor { get; set; }
        public int NumOfPayments { get; set; }
        public string Title { get; set; }
        public enum DayOfWeek { } 

        public Lesson()
        {
            Student Student = new Student();
            Payment Payment = new Payment();
        }
    }
}