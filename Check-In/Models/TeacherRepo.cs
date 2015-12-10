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

        public bool AddClass(int _teacher_id, Teacher _list)
        {
            var query = from b in TeacherContext.Teachers where b.TeacherId == _teacher_id select b;
            Teacher found_teacher = null;

            bool result = true;
            try
            {
                found_teacher = query.Single<Teacher>();
                found_teacher.L.Add(Lesson);
                TeacherContext.SaveChanges();
            }

            catch (InvalidOperationException)
            {
                result = false;
            }

            return result;
        }

        
    }

}