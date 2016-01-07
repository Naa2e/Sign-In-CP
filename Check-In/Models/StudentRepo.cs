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

        public bool AddNewStudent(int _lesson_id, Student _student)
        {

            var query = from b in LessonContext.Lessons where b.LessonId == _lesson_id select b;
            Student found_lesson = null;

            bool result = true;

            try
            {
                found_lesson = query.Single<Lesson>();
                StudentContext.Students.Add(_student);
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
}