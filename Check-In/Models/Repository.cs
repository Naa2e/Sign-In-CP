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
        public IDbSet<ApplicationUser> Admin { get { return Context.Users; } }


        public Repository()
        {
            Context = new CContext();
        }

        public Repository(CContext _context)
        {
            Context = _context;
        }

        public bool AddNewTeacher(Teacher _teacher) //(argument area: Class New Variable)
        {
            bool result = true;
            try
            {
                Context.Teachers.Add(_teacher);
                Context.SaveChanges();
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
                Context.Payments.Add(_Payment);
                Context.SaveChanges();
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
            var query = from b in Context.Teachers where b.TeacherId == _teacher_id select b;
            Teacher found_teacher = null;

            bool result = true;

            try
            {
                found_teacher = query.Single<Teacher>();
                Context.Lessons.Add(_lesson);
                Context.SaveChanges();
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
            var query = from b in Context.Lessons where b.LessonId == _lesson_id select b;
            Lesson found_lesson = null;

            bool result = true;

            try
            {
                found_lesson = query.Single<Lesson>();
                Context.Lessons.Remove(found_lesson);
                Context.SaveChanges();
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

        public string EditLessonName(string _title)
        {
            return null;
        }

        public bool AddNewStudent(int _lesson_id, Student _student)
        {

            var query = from b in Context.Lessons where b.LessonId == _lesson_id select b;
            Lesson found_lesson = null;

            bool result = true;

            try
            {
                found_lesson = query.Single<Lesson>();
                found_lesson.Class.Add(_student);
                Context.SaveChanges();
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

        public int RetrieveNumOfStudents(Student _student)
        {
            return 0;
        }

        public string EditStudentName(Student _student)
        {
            return null;
        }

        public string DeleteStudent(Student _student)
        {
            return null;
        }
    }    
}
