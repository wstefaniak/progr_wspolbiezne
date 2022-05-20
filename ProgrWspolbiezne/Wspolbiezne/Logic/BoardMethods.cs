using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using Data;
using System.Collections.ObjectModel;

namespace Logic
{
    public class BoardMethods : AbstractBoardMethods
    {
        private readonly DataAbstractApi _data;
        public BoardMethods(DataAbstractApi dataAbstractApi)
        {
            _data = dataAbstractApi;
        }

        public override int Height { get { return _data.Height; } }
        public override int Width { get { return _data.Width; } }

        public override void CreateBalls(int amount)
        {
            _balls = new List<BallMethods>();
            _data.CreateBalls(amount);
            foreach (Ball ball in _data.GetBalls())
            {
                _balls.Add(new BallMethods(ball));
                ball.PropertyChanged += CollisionCheck;
            }
        }

        public override void StartMove() => _data.StartMove();
        public override void StopMove() => _data.StopMove();
        public override List<BallMethods> GetBalls() => _balls;
        public override ObservableCollection<Ball> Balls => _data.GetBalls();

        public void Bounce(Ball ball1, Ball ball2)
        {
            Vector2 direction1 = ball1.MoveDirection - (2 * ball2.Mass / (ball1.Mass + ball2.Mass) * Vector2.Dot(ball1.MoveDirection - ball2.MoveDirection, ball1.Center - ball2.Center) / (ball1.Center - ball2.Center).LengthSquared() * (ball1.Center - ball2.Center));
            Vector2 direction2 = ball2.MoveDirection - (2 * ball1.Mass / (ball1.Mass + ball2.Mass) * Vector2.Dot(ball2.MoveDirection - ball1.MoveDirection, ball2.Center - ball1.Center) / (ball2.Center - ball1.Center).LengthSquared() * (ball2.Center - ball1.Center));
            ball1.MoveDirection = direction1;
            ball2.MoveDirection = direction2;
        }
        public async void Collision(int Width, int Height, Ball ball)
        {
            foreach (BallMethods ballMethods in _balls)
            {
                float distanceBefore = Vector2.Distance(ballMethods.Ball.Center, ball.Center);
                float distanceAfter = Vector2.Distance(ballMethods.Ball.Center + ballMethods.Ball.MoveDirection, ball.Center + ball.MoveDirection);
                if (ballMethods.Ball == ball) { continue; }
                if (distanceBefore <= ballMethods.Ball.Radius + ball.Radius)
                {
                    if (distanceBefore - distanceAfter > 0)
                    {
                        Bounce(ball, ballMethods.Ball);
                    }
                }
            }
            if (ball.Center.X < ball.Radius || ball.Center.X > Width) { ball.DirectionX *= -1; }
            if (ball.Center.Y < ball.Radius || ball.Center.Y > Height) { ball.DirectionY *= -1; }
        }

        public void CollisionCheck(object obj, PropertyChangedEventArgs args)
        {
            Ball ball = (Ball)obj;
            if (args.PropertyName == "_center")
            {
                Collision(Width, Height, ball);
            }
        }
    }
}
