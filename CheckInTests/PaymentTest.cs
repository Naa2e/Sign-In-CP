using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_In.Models;

namespace CheckInTests
{
    [TestClass]
    public class PaymentTest
    {
        [TestMethod]
        public void PaymentEnsureICanCreateAnInstance()
        {
            Payment Revenue = new Payment();
            Assert.IsNotNull(Revenue);
        }
    }
}
