using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_In.Models;

namespace CheckInTests
{
    [TestClass]
    public class StudentTest
    {
        public void StudentEnsureICanCreateANewInstance()
        {
            Student Class = new Student();
            Assert.IsNotNull(Class);
        }
    }
}
