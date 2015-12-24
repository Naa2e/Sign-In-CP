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
    public class TeacherRepoTest
    {
        private Mock<CContext> mock_context;
        private Mock<DbSet<Teacher>> mock_teacher;
        private List<Teacher> my_list;
        private ApplicationUser owner;

        [TestMethod]
        public void TeacherRepoEnsureICanCreateAnInstance()
        {
            TeacherRepo Repo = new TeacherRepo();
            Assert.IsNotNull(Repo);

        }

        [TestMethod]
        public void TeacherRepoEnsureICanCreateNewTeacher() //One Test per method
        {
            //Arrange - Setup
            List<Teacher> my_list = new List<Teacher>(); //Create new instances of empty list
            mock_context = new Mock<CContext>(); //Mock DbContext
            Mock<DbSet<Teacher>> mock_teacher = new Mock<DbSet<Teacher>>(); //Mock all DbSets in Context file 
            Mock<DbSet<Student>> mock_student = new Mock<DbSet<Student>>();
            Mock<DbSet<Payment>> mock_payment = new Mock<DbSet<Payment>>();
            Mock<DbSet<Lesson>> mock_lesson = new Mock<DbSet<Lesson>>();

            var data = my_list.AsQueryable(); //this variable will make my list of teachers into a table

            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_teacher.As<IQueryable<Teacher>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_teacher.Setup(m => m.Add(It.IsAny<Teacher>())).Callback((Teacher b) => my_list.Add(b));

            mock_context.Setup(m => m.Teachers).Returns(mock_teacher.Object); //Teachers comes form variable in context class

            TeacherRepo Repo = new TeacherRepo(mock_context.Object);
            Teacher Instructor = new Teacher { Name = "Shalene" }; //instance of a teacher 


            //Act - Call method that is being tested
            bool Success = Repo.AddNewTeacher(Instructor); //type NewVarname = RepoInstance.Method(ClassInstance);

            //Assert - check result

            Assert.AreEqual(1, Repo.TeacherContext.Teachers.Count());
        }

    }
}
