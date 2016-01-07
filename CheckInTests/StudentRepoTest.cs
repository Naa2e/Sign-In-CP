using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_In.Models;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckInTests
{
    [TestClass]
    public class StudentRepoTest
    {
        private Mock<CContext> mock_context;
        private Mock<DbSet<Student>> mock_student;
        private List<Student> my_list;
        private ApplicationUser owner;

        [TestMethod]
        public void StudentRepoEnsureICanCreateAnInstance()
        {
            StudentRepo Repo = new StudentRepo();
            Assert.IsNotNull(Repo);
        }

        [TestMethod]
        public void AddStudentToLesson()
        {
            //Arrange
            List<Teacher> TList = new List<Teacher>();
            List<Lesson> LLists = new List<Lesson>();
            List<Student> SList = new List<Student>();

            TList.Add(new Teacher { Name = "Shalene", TeacherId = 1 });
            LLists.Add(new Lesson { LessonId = 1, Title = "Private" });
            SList.Add(new Student { Name = "Nikki", StudentID = 1 });

            Mock<CContext> mock_context = new Mock<CContext>();
            Mock<DbSet<Teacher>> mock_teacher = new Mock<DbSet<Teacher>>();
            Mock<DbSet<Student>> mock_student = new Mock<DbSet<Student>>();
            Mock<DbSet<Lesson>> mock_lesson = new Mock<DbSet<Lesson>>();

            var data = SList.AsQueryable();

            mock_student.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_student.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_student.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_student.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_student.Setup(m => m.Add(It.IsAny<Student>())).Callback((Student b) => SList.Add(b));
            mock_context.Setup(m => m.Students).Returns(mock_student.Object);

            StudentRepo Repo = new StudentRepo(mock_context.Object);
            Student Class = new Student { Name = "Nikki" };

            //Act
            bool success = Repo.AddNewStudent(1, Class);

            //Assert
            Assert.AreEqual(1, Repo.StudentContext.Students.Count());
            Assert.IsFalse(success);
        }
    }

}
