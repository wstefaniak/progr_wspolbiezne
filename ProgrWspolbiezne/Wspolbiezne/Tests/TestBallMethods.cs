using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public class TestBallMethods
    {
        static readonly int radius = 35;
        [TestMethod]
        public void TestConstructor()
        {
            BallMethods ball = new BallMethods();
            Assert.AreEqual(radius, ball.Radius);
        }

        [TestMethod]
        public void TestCenter()
        {
            BallMethods ball = new BallMethods();
            Vector2 center = new Vector2(100, 200);
            ball.Center = center;
            Assert.AreEqual(center, ball.Center);
            Assert.AreEqual(100, ball.X);
            Assert.AreEqual(200, ball.Y);
        }

        [TestMethod]
        public void TestMove()
        {
            BallMethods ball = new BallMethods();
            ball.MoveDirection = new Vector2(-5, 5);
            ball.Center = new Vector2(100, 200);
            ball.Move();
            Assert.AreEqual(100 - 5, ball.Center.X);
            Assert.AreEqual(200 + 5, ball.Center.Y);
        }
    }
}