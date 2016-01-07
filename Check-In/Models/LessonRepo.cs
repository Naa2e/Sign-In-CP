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

        
}