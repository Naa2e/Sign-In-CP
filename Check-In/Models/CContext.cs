using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Check_In.Models
{
    public class CContext : ApplicationDbContext
    {
        public virtual IDbSet<Teacher> Teachers { get; set; }
        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Payment> Payments { get; set; }
        public virtual IDbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}