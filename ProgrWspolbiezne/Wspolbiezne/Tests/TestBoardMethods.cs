using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class TestBoardMethods
    {
        static readonly int amount = 10;
        [TestMethod]
        public void TestConstructor()
        {
            AbstractBoardMethods board = new AbstractBoardMethods();
            Assert.AreEqual(0, board.Balls.Count);
        }

        [TestMethod]
        public void TestCreateBalls()
        {
            AbstractBoardMethods board = new AbstractBoardMethods();
            board.CreateBalls(amount);
            Assert.AreEqual(amount, board.Balls.Count);
            board.Balls.Clear();
            board.CreateBalls(amount+5);
            Assert.AreEqual(amount+5, board.Balls.Count);
            Assert.ThrowsException<Exception>(() => board.CreateBalls(-50));
        }

        [TestMethod]
        public void TestClearBalls()
        {
            AbstractBoardMethods board = new AbstractBoardMethods();
            board.CreateBalls(amount);
            Assert.AreEqual(amount, board.Balls.Count);
            board.Balls.Clear();
            Assert.AreEqual(0, board.Balls.Count);
        }

        [TestMethod]
        public void TestStartStop()
        {
            AbstractBoardMethods board = new AbstractBoardMethods();
            board.CreateBalls(amount);
            Assert.AreEqual(amount, board.Balls.Count);
            board.Start();
            Assert.AreEqual(amount, board.TasksAmount);
            board.Stop();
            Assert.AreEqual(0, board.TasksAmount);
        }
    }
}