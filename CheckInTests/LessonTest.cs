using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_In.Models;

namespace CheckInTests
{
    [TestClass]
    public class LessonTest
    {
        [TestMethod]
        public void LessonEnsureICanCreateANewInstance()
        {
            Lesson Schedule = new Lesson();
            Assert.IsNotNull(Schedule);
        }
    }
}
