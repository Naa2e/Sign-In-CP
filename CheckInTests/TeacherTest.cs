using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_In.Models;

namespace CheckInTests
{
    [TestClass]
    public class TeacherTest
    {
        [TestMethod]
        public void TeacherEnsureICanCreateAnInstance()
        {
            Teacher Instructor = new Teacher();
            Assert.IsNotNull(Instructor);
        }
    }
}
