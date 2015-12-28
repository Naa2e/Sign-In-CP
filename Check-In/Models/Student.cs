using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }

        public virtual Lesson Lesson { get; set; }
        //public virtual List<Lesson> Courses { get; set; } //Why not this?

        public Student()
        {
            Lesson = new Lesson();
        }
    }
}