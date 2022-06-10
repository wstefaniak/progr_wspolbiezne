using Logic;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public class TestLogic
    {
        static readonly int amount = 10;
        DataAbstractApi dataAbstractApi = new DataApi();
        [TestMethod]
        public void TestConstructor()
        {
            
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            Assert.AreEqual(830, board.Width);
            Assert.AreEqual(700, board.Height);
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
            Assert.AreEqual(amount + 5, board.Balls.Count);
            for (int i = 0; i < amount; i++)
            {
                Assert.IsTrue(board.Balls[i].X < board.Width);
                Assert.IsTrue(board.Balls[i].Y < board.Height);
                Assert.IsTrue(board.Balls[i].X > 0);
                Assert.IsTrue(board.Balls[i].Y > 0);
            }
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => board.CreateBalls(-50));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => board.CreateBalls(0));
        }

        [TestMethod]
        public void TestCollision()
        {
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            board.CreateBalls(1);
            Vector2 c = new Vector2(-100, -100);
            Vector2 mv = new Vector2(1, 1);
            Ball ball = new Ball(c);
            ball.MoveDirection = mv;
            Assert.AreEqual(1, ball.DirectionX);
            Assert.AreEqual(1, ball.DirectionY);
            board.Collision(830, 700, ball);
            Assert.AreEqual(-1, ball.DirectionX);
            Assert.AreEqual(-1, ball.DirectionY);
        }

        [TestMethod]
        public void TestBounce()
        {
            AbstractBoardMethods board = new BoardMethods(dataAbstractApi);
            Vector2 c1 = new Vector2(100, 100);
            Vector2 c2 = new Vector2(150, 150);
            Vector2 mv1 = new Vector2(1, 2);
            Vector2 mv2 = new Vector2(-2, -3);
            Ball ball1 = new Ball(c1);
            Ball ball2 = new Ball(c2);
            ball1.MoveDirection = mv1;
            ball2.MoveDirection = mv2;
            ball1.Mass = 0.5F;
            ball2.Mass = 0.6F;
            Assert.AreEqual(mv1, ball1.MoveDirection);
            Assert.AreEqual(mv2, ball2.MoveDirection);
            board.Bounce(ball1, ball2);
            Assert.AreNotEqual(mv1, ball1.MoveDirection);
            Assert.AreNotEqual(mv2, ball2.MoveDirection);
        }
    }
}