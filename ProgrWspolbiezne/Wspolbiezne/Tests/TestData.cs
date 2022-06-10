using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using Data;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class TestData
    {
        DataAbstractApi data = new DataApi();
        static readonly int amount = 10;
        [TestMethod]
        public void TestDataApi()
        {
            Assert.AreEqual(830, data.Width);
            Assert.AreEqual(700, data.Height);
            data.CreateBalls(amount);
            Assert.AreEqual(amount, data.GetBalls().Count);
            for (int i = 0; i < amount; i++)
            {
                Assert.IsTrue((data.GetBalls()[i].X < data.Width));
                Assert.IsTrue((data.GetBalls()[i].Y < data.Height));
                Assert.IsTrue(data.GetBalls()[i].X > 0);
                Assert.IsTrue(data.GetBalls()[i].Y > 0);
            }
            data.StopMove();
            Assert.AreEqual(0, data.GetBalls().Count);
        }

        [TestMethod]
        public void TestBalls()
        {
            data.CreateBalls(amount);
            Assert.AreEqual(amount, data.GetBalls().Count);
            for (int i = 0; i < amount; i++)
            {
                Assert.IsTrue(data.GetBalls()[i].Mass < 1.0F);
                Assert.IsTrue(data.GetBalls()[i].Mass >= 0.0F);
                Assert.IsTrue(data.GetBalls()[i].X < data.Width - 50);
                Assert.IsTrue(data.GetBalls()[i].Y < data.Height - 50);
                Assert.IsTrue(data.GetBalls()[i].X >= 50);
                Assert.IsTrue(data.GetBalls()[i].Y >= 50);
                Assert.IsFalse(data.GetBalls()[i].DirectionX == 0);
                Assert.IsFalse(data.GetBalls()[i].DirectionY == 0);
            }
        }

        [TestMethod]
        public void TestCreateBalls()
        {
            data.CreateBalls(5);
            Assert.AreEqual(5, data.GetBalls().Count);
            data.CreateBalls(10);
            Assert.AreEqual(15, data.GetBalls().Count);
            data.CreateBalls(7);
            Assert.AreEqual(22, data.GetBalls().Count);
            data.StopMove();
            Assert.AreEqual(0, data.GetBalls().Count);
            data.CreateBalls(amount);
            Assert.AreEqual(amount, data.GetBalls().Count);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => data.CreateBalls(-5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => data.CreateBalls(0));
        }
    }
}