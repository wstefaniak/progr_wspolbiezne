using Logic;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class TestBoardMethods
    {
        static readonly int amount = 10;
        DataAbstractApi dataAbstractApi = new DataApi();
        [TestMethod]
        public void TestConstructor()
        {
            
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            Assert.AreEqual(0, board.Balls.Count);
        }

        [TestMethod]
        public void TestCreateBalls()
        {
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            board.CreateBalls(amount);
            Assert.AreEqual(amount, board.Balls.Count);
            board.Balls.Clear();
            Assert.AreEqual(0, board.Balls.Count);
            board.CreateBalls(amount+5);
            Assert.AreEqual(amount+5, board.Balls.Count);
            Assert.ThrowsException<Exception>(() => board.CreateBalls(-50));
        }

        [TestMethod]
        public void TestClearBalls()
        {
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            board.CreateBalls(amount);
            Assert.AreEqual(amount, board.Balls.Count);
            board.Balls.Clear();
            Assert.AreEqual(0, board.Balls.Count);
        }

        [TestMethod]
        public void TestStartStop()
        {
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            board.CreateBalls(amount);
            Assert.AreEqual(amount, board.Balls.Count);
            board.StartMove();
            Assert.AreEqual(amount, board.GetBalls().Count);
            board.StopMove();
            Assert.AreEqual(0, board.GetBalls().Count);
        }
    }
}