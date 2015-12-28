using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class LessonRepo
    {
        public CContext LessonContext;
        public CContext TeacherContext;
        public IDbSet<ApplicationUser> Admin { get { return LessonContext.Users; } }

        public LessonRepo()
        {
            LessonContext = new CContext();
            TeacherContext = new CContext();
        }

        public LessonRepo(CContext _context)
        {
            LessonContext = _context;
            TeacherContext = _context;
        }

        public bool AddNewLesson(int _teacher_id, Lesson _lesson)
        {
            var query = from b in TeacherContext.Teachers where b.TeacherId == _teacher_id select b;
            Teacher found_teacher = null; //Can't be null

            bool result = true;

            try
            {
                found_teacher = query.Single<Teacher>();
                LessonContext.Lessons.Add(_lesson);
                LessonContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result =false;
            }
            catch (ArgumentNullException)
            {
                result = false;
            }
            return result;
        }

        public bool DeleteLesson(int _lesson_id)
        {
            var query = from b in TeacherContext.Teachers where b.TeacherId == _teacher_id select b;
            Teacher found_teacher = null;
            bool result = true;
            try
            {
                //LessonContext.Lessons.Remove();
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
    }
    //public string EditLessonName(string _title) { return null; }

}