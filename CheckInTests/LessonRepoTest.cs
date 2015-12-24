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
    public class LessonRepoTest
    {
        private Mock<CContext> mock_context;
        private Mock<DbSet<Lesson>> mock_lesson;
        private List<Lesson> my_list;
        private ApplicationUser owner;

        [TestMethod]
        public void LessonRepoEnsureICanCreateAnInstance()
        {
            LessonRepo Repo = new LessonRepo();
            Assert.IsNotNull(Repo);
        }

        [TestMethod]
        public void LessonRepoEnsureICanCreateNewLesson() 
        {
            //Arrange - Setup
            List<Lesson> my_list = new List<Lesson>(); 
            Mock<CContext> mock_context = new Mock<CContext>(); 
            Mock<DbSet<Teacher>> mock_teacher = new Mock<DbSet<Teacher>>(); 
            Mock<DbSet<Student>> mock_student = new Mock<DbSet<Student>>();
            Mock<DbSet<Payment>> mock_payment = new Mock<DbSet<Payment>>();
            Mock<DbSet<Lesson>> mock_lesson = new Mock<DbSet<Lesson>>();

            var data = my_list.AsQueryable(); 

            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_lesson.Setup(m => m.Add(It.IsAny<Lesson>())).Callback((Lesson b) => my_list.Add(b));

            mock_context.Setup(m => m.Lessons).Returns(mock_lesson.Object); 

            LessonRepo Repo = new LessonRepo(mock_context.Object);
            Lesson Schedule = new Lesson { LessonId = 1 };


            //Act - Call method that is being tested
            int Success = Repo.AddNewLesson(1, Schedule); 
            
            //Assert - check result

            Assert.AreEqual(1, Repo.LessonContext.Lessons.Count());
        }
        [TestMethod]
        public void EnsureICanDeleteLessonTest()
        {
            //Arrange
            List<Lesson> my_list = new List<Lesson>();
            Mock<CContext> mock_context = new Mock<CContext>();
            Mock<DbSet<Teacher>> mock_teacher = new Mock<DbSet<Teacher>>();
            Mock<DbSet<Student>> mock_student = new Mock<DbSet<Student>>();
            Mock<DbSet<Payment>> mock_payment = new Mock<DbSet<Payment>>();
            Mock<DbSet<Lesson>> mock_lesson = new Mock<DbSet<Lesson>>();

            var data = my_list.AsQueryable();

            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_lesson.As<IQueryable<Lesson>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_lesson.Setup(m => m.Add(It.IsAny<Lesson>())).Callback((Lesson b) => my_list.Add(b));

            mock_context.Setup(m => m.Lessons).Returns(mock_lesson.Object);

            LessonRepo Repo = new LessonRepo(mock_context.Object);
            my_list.Add(new Lesson { LessonId = 1, Title = "Private" });

            //Act
            bool Success = Repo.DeleteLesson(1);

            //Assert
            Assert.AreEqual(0, Repo.LessonContext.Lessons.Count());

         }
    }
}
