using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_In.Models;
using Moq;

namespace CheckInTests
{
    [TestClass]
    public class TeacherRepoTest
    {
        [TestMethod]
        public void TeacherRepoEnsureICanCreateAnInstance()
        {
            TeacherRepo Repo = new TeacherRepo();
            Assert.IsNotNull(Repo);
          
        }

        [TestMethod]
        public void TeacherRepoEnsureICanCreateNewTeacher() //One Test per method
        {
            //Arrange Setup
            TeacherRepo Repo = new TeacherRepo();
            Teacher Instructor = new Teacher { Name = "Shalene" }; //instance of a teacher 

            //Act Call method that is being tested
            bool Success = Repo.AddNewTeacher(Instructor); //type NewVarname = RepoInstance.Method(ClassInstance);

            //Assert check result
            Assert.IsTrue(Success);
        }
    }
}
