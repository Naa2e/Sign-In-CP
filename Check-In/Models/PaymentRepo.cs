using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class PaymentRepo
    {
        public CContext PaymentContext;
        public IDbSet<ApplicationUser> Admin { get { return PaymentContext.Users; } }

        public PaymentRepo()
        {
            PaymentContext = new CContext();
        }

        public PaymentRepo(CContext _context)
        {
            PaymentContext = _context;
        }

        public string AddNewPayment(Payment _Payment)
        {  //(argument area: Class New Variable)

            string result = ("Class Pass");
            try
            {
                PaymentContext.Payments.Add(_Payment);
                PaymentContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result = null;
            }
            catch (ArgumentNullException)
            {
                result = null;
            }
            return result;
        }
    }
}