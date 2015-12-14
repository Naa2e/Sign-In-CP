using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Payment
    {
        public int PayAmt { get; set; }
        public string PayType { get; set; }

        public virtual Lesson Lesson { get; set; }

        public Payment()
        {
            Lesson = new Lesson();
        }
    }
}