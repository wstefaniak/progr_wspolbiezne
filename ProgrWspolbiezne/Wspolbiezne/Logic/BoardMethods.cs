using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class BoardMethods
    {
        public static int BoardWidth = 1280;
        public static int BoardHeight = 950;
        private ObservableCollection<BallMethods> _balls = new ObservableCollection<BallMethods>();
        private List<Task> _tasks = new List<Task>();

        public BoardMethods()
        {
        }
        public ObservableCollection<BallMethods> Balls
            {
                get => _balls;
            }

        public int TasksAmount
        {
            get => _tasks.Count;
        }

        public void CreateBalls(int amount)
        {
            Random random = new Random();

            if (amount < 0)
            {
                throw new Exception("Invalid input");
            }

            if (Balls.Count != 0)
            {
                _tasks.Clear();
                Balls.Clear();
            }

            for (int i = 0; i < amount; i++)
            {
                BallMethods ball = new BallMethods();
                ball.MoveDirection = new Vector2((float)3.75, (float)3.75);
                ball.Center = new Vector2(random.Next(50, BoardWidth-50), random.Next(50, BoardHeight-50));
                _balls.Add(ball);
            }
        }
        public void Start()
        {
            foreach (BallMethods ball in _balls)
            {
                Task task = Task.Run(() =>
                {
                    while (true)
                    {
                        ball.Move();
                        Thread.Sleep(10);
                    }
                }
                );
                _tasks.Add(task);
            }
        }
        public void Stop()
        {
            _tasks.Clear();
            _balls.Clear();
        }
    }
}