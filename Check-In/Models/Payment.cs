using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int PayAmt { get; set; }
        public string PayType { get; set; }

        public virtual Lesson Lesson { get; set; }

        public Payment()
        {
            Lesson = new Lesson();
        }
    }
}