using Microsoft.VisualStudio.TestTools.UnitTesting;
using Etap0;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMethodTest()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(10, calculator.Add(8, 2));
        }

        [TestMethod]
        public void SubMethodTest()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(-4.5, calculator.Sub(3.5, 8));
        }

        [TestMethod]
        public void MulMethodTest()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(77, calculator.Mul(7, 11));
        }

        [TestMethod]
        public void DivMethodTest()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(1.4, calculator.Div(14, 10));
        }
    }
}