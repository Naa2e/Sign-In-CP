using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class TeacherRepo
    {
        public CContext TeacherContext;
        public IDbSet<ApplicationUser> Admin { get { return TeacherContext.Users; } }

        public TeacherRepo()
        {
            TeacherContext = new CContext();
        }

        public TeacherRepo(CContext _context)
        {
            TeacherContext = _context;
        }

        public bool AddNewTeacher(Teacher _teacher)
        {  //(argument area: Class New Variable)

            bool result = true;
            try
            {
                TeacherContext.Teachers.Add(_teacher);
                TeacherContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result = false;
            }
            catch (ArgumentNullException)
            {
                result = false;
            }
            return result;
        }

        public string EditTeacherName(Teacher _teacher) { return null; }
        public string DeleteTeacher(Teacher _teacher) { return null; }

        public string EditAcceptedPayTypes() { return null; }

        public int RetrieveNumOfPayments() { return 0; }

        public string AddDayOfWeek() { return null; }
        public string EditDayOfWeek() { return null; }

        public string AddPaymentType() { return null; }
        public string EditPaymentType() { return null; }
        public string DeletePaymentType() {return null;}
    }
}