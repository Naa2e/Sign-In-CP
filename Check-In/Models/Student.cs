using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Student
    {
        public string Name { get; set; }

        public virtual Lesson Lesson { get; set; }
        //public virtual List<Lesson> Courses { get; set; } //Why not this?

        public Student()
        {
            Lesson = new Lesson();
        }
    }
}