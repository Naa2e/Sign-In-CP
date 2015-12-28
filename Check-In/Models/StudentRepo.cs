using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class StudentRepo
    {
        public CContext StudentContext;
        public IDbSet<ApplicationUser> Admin { get { return StudentContext.Users; } }

        public StudentRepo()
        {
            StudentContext = new CContext();
        }

        public StudentRepo(CContext _context)
        {
            StudentContext = _context;
        }

        public string AddNewStudent(Student _student)
        {
            string result = null ;
            try
            {
                StudentContext.Students.Add(_student);
                StudentContext.SaveChanges();
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
        public int RetrieveNumOfStudents(Student _student) { return 0; }
        public string EditStudentName(Student _student) { return null; }
        public string DeleteStudent(Student _student) { return null; }

    }
}