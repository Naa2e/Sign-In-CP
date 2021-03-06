﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Check_In.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public virtual List<Lesson> Schedule { get; set; }


        public Teacher()
        {
            Schedule = new List<Lesson>();
        }
    }
}

//finish models and relatiosnhips based on ERD
//teach repo list of methods with proper arguments listed out
