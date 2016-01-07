using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Check_In.Models;
using Moq;
using System.Collections.Generic;

namespace CheckInTests
{
    [TestClass]
    public class RepositoryTests
    {
        private Mock<CContext> mock_context;
        private Mock<DbSet<Lesson>> mock_lesson;
        private Mock<DbSet<Student>> mock_student;
        private Mock<DbSet<Payment>> mock_payment;
        private Mock<DbSet<Teacher>> mock_teacher;
        private List<Payment> PList;
        private List<Teacher> TList; 
        private List<Lesson> LLists;
        private List<Student> SList;
        private ApplicationUser owner;

            


        [TestMethod]
        public void TeacherRepoEnsureICanCreateAnInstance()
        {
            Repository Repo = new Repository();
            Assert.IsNotNull(Repo);
        }

        [TestMethod]
        public void TeacherRepoEnsureICanCreateNewTeacher() //One Test per method
        {
            //Arrange - Setup
            TList = new List<Teacher>(); //Create new instances of empty list
            mock_context = new Mock<CContext>(); //Mock DbContext
            mock_teacher = new Mock<DbSet<Teacher>>(); //Mock all DbSets in Context file 
            mock_student = new Mock<DbSet<Student>>();
            mock_payment = new Mock<DbSet<Payment>>();
            mock_lesson = new Mock<DbSet<Lesson>>();

            var data = TList.AsQueryable(); //this variable will make my list of teachers into a table

            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_teacher.Setup(m => m.Add(It.IsAny<Teacher>())).Callback((Teacher b) => TList.Add(b));

            mock_context.Setup(m => m.Teachers).Returns(mock_teacher.Object); //Teachers (with the s) comes from variable in context class

            Repository Repo = new Repository(mock_context.Object);
            Teacher Instructor = new Teacher { Name = "Shalene" }; //instance of a teacher; name the properties you want to test


            //Act - Call method that is being tested
            bool Success = Repo.AddNewTeacher(Instructor); //type NewVarname = RepoInstance.Method(ClassInstance);

            //Assert - check result

            Assert.AreEqual(1, Repo.TeacherContext.Teachers.Count());
        }

        [TestMethod]
        public void TeacherRepoEnsureICanDeleteATeacher()
        {
            //Arrange
            TList = new List<Teacher>();
            mock_context = new Mock<CContext>();
            mock_teacher = new Mock<DbSet<Teacher>>();
            Mock<DbSet<Student>> mock_student = new Mock<DbSet<Student>>();
            Mock<DbSet<Payment>> mock_payment = new Mock<DbSet<Payment>>();
            Mock<DbSet<Lesson>> mock_lesson = new Mock<DbSet<Lesson>>();

            var data = TList.AsQueryable();

            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_teacher.Setup(m => m.Add(It.IsAny<Teacher>())).Callback((Teacher b) => TList.Add(b));

            mock_context.Setup(m => m.Teachers).Returns(mock_teacher.Object);

            Repository Repo = new Repository(mock_context.Object);
            Teacher Instructor = new Teacher { Name = "Shalene" };
        }

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
            TList = new List<Teacher>();
            LLists = new List<Lesson>();
            SList = new List<Student>();

            TList.Add(new Teacher { Name = "Shalene", TeacherId = 1 }); //create real properties to test
            LLists.Add(new Lesson { LessonId = 1, Title = "Private" });
            SList.Add(new Student { Name = "Nikki", StudentID = 1 });

            mock_context = new Mock<CContext>();
            mock_teacher = new Mock<DbSet<Teacher>>();
            mock_student = new Mock<DbSet<Student>>();
            mock_lesson = new Mock<DbSet<Lesson>>();

            var data = SList.AsQueryable();

            mock_student.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_student.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_student.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_student.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_student.Setup(m => m.Add(It.IsAny<Student>())).Callback((Student b) => SList.Add(b));
            mock_context.Setup(m => m.Students).Returns(mock_student.Object);

            Repository Repo = new Repository(mock_context.Object);
            Student Class = new Student { Name = "Nikki" };

            //Act
            bool success = Repo.AddNewStudent(1, Class);

            //Assert
            Assert.AreEqual(1, Repo.StudentContext.Students.Count());
            Assert.IsFalse(success);
        }
    }
}
