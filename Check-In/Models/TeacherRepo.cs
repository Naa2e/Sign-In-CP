using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class TeacherRepo
    {

        private Context TeacherContext;

        public IDbSet<ApplicationUser> Admin { get { return TeacherContext.Users; } }

        public TeacherRepo()
        {
            TeacherContext = new Context();
        }

        public TeacherRepo(Context _context)
        {
            TeacherContext = _context;
        }

   
        public bool AddNewTeacher(Teacher _teacher) { return true; }

        public string EditTeacherName() { return null; }
        public string DeleteTeacherbyID() { return null; }//will this delete the entire entity if its the key?
        public int RetrieveNumOfStudents() { return 0; }
        public string AddNewStudent() { return null; }
        public string EditStudentName() { return null; }
        public string DeleteStudent() { return null; }
       // public string MergeStudent() { return null; } //I'm thinking this will be needed if a student enters their name differently. 
        //I assume its case sensitive so merge Nicole Ahima with nicole ahima, or like SuNtRuSt I could add toLowerCase? 
        //But this won't account for Nicole Ahima vs Nicole A (laziness)
        //Now that I'm thinking of it I could make a seperate text box for last name that requires a minimum of 2 letters and just throw it all to lower case
        //Nice talk rubber duck

        public string AddNewLesson(int _teacher_id, Lesson _lesson)
        { return null; }
        public string EditLessonTitle() { return null; }
        public string DeleteLesson() { return null; }

        public string EditLessonName() { return null; }
      
    
        public string EditAcceptedPayTypes() { return null; }

        public int RetrieveNumOfPayments() { return 0; }

        public string AddDayOfWeek() { return null; }
        public string EditDayOfWeek() { return null; }

        public string AddPaymentType() { return null; }
        public string EditPaymentType() { return null; }
        public string DeletePaymentType() { return null; }

        public int AddPaymentAmt() { return 0; }
        public int EditPaymentAmt() { return 0; }
        public int DeletePaymentAmt() { return 0; }


    }

}