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
        public IDbSet<ApplicationUser> Admin { get { return LessonContext.Users; } }

        public LessonRepo()
        {
            LessonContext = new CContext();
        }

        public LessonRepo(CContext _context)
        {
            LessonContext = _context;
        }

        public int AddNewLesson(int _teacher_id, Lesson _lesson)
        {
            int result = 1;
            try
            {

                LessonContext.Lessons.Add(_lesson);
                LessonContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result = 0;
            }
            catch (ArgumentNullException)
            {
                result = 0;
            }
            return result;
        }

        public bool DeleteLesson(int _lesson_id)
        {
            bool result = true;
            try
            {
                //LessonContext.Lessons.Remove(_lesson_id);
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