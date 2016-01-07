using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class Repository
    {
        public CContext Context;
        public CContext PaymentContext;
        public CContext LessonContext;
        public CContext StudentContext;
        public IDbSet<ApplicationUser> Admin { get { return TeacherContext.Users; } }
        public IDbSet<ApplicationUser> Admin1 { get { return PaymentContext.Users; } }
        public IDbSet<ApplicationUser> Admin2 { get { return LessonContext.Users; } }
        public IDbSet<ApplicationUser> Admin3 { get { return StudentContext.Users; } }

        public Repository()
        {
            TeacherContext = new CContext();
            PaymentContext = new CContext();
            LessonContext = new CContext();
            StudentContext = new CContext();
        }

        public Repository(CContext _context)
        {
            TeacherContext = _context;
            PaymentContext = _context;
            LessonContext = _context;
            StudentContext = _context;
        }

        public bool AddNewTeacher(Teacher _teacher) //(argument area: Class New Variable)
        {
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

        public string EditTeacherName(Teacher _teacher)
        {
            return null;

        }

        public string DeleteTeacher(Teacher _teacher)
        {
            return null;
        }

        public string AddNewPayment(Payment _Payment) //(argument area: Class New Variable)
        {  

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

        public string EditPaymentType()
        {
            return null;
        }

        public string DeletePaymentType()
        {
            return null;
        }

        public bool AddNewLesson(int _teacher_id, Lesson _lesson)
        {
            var query = from b in TeacherContext.Teachers where b.TeacherId == _teacher_id select b;
            Teacher found_teacher = null;

            bool result = true;

            try
            {
                found_teacher = query.Single<Teacher>();
                LessonContext.Lessons.Add(_lesson);
                LessonContext.SaveChanges();
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

        public bool DeleteLesson(int _lesson_id)
        {
            var query = from b in LessonContext.Lessons where b.LessonId == _lesson_id select b;
            Lesson found_lesson = null;

            bool result = true;

            try
            {
                found_lesson = query.Single<Lesson>();
                LessonContext.Lessons.Remove(found_lesson);
                LessonContext.SaveChanges();
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

        public bool AddNewStudent(int _lesson_id, Student _student)
        {

            var query = from b in LessonContext.Lessons where b.LessonId == _lesson_id select b;
            Student found_lesson = null;

            bool result = true;

            try
            {
                found_lesson = query.Single<Lesson>();
                found_lesson.StudentID.Add(_student);
                //StudentContext.Students.Add(_student);
                StudentContext.SaveChanges();
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
        public int RetrieveNumOfStudents(Student _student) { return 0; }
        public string EditStudentName(Student _student) { return null; }
        public string DeleteStudent(Student _student) { return null; }
    }
    //public string EditLessonName(string _title) { return null; }


}
}