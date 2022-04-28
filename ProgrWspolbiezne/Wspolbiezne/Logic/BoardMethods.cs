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
        public static int BoardWidth = 830;
        public static int BoardHeight = 700;
        private ObservableCollection<BallMethods> _balls = new ObservableCollection<BallMethods>();
        private List<Task> _tasks = new List<Task>();
        public CancellationTokenSource _cts;
        public CancellationToken _ct;

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

            if (Balls.Count == 0)
            {
                _tasks.Clear();
                Balls.Clear();
            }
            _cts = new CancellationTokenSource();
            _ct = _cts.Token;
            for (int i = 0; i < amount; i++)
            {
                bool tmp = true;
                int g = 0, h = 0;
                BallMethods ball = new BallMethods();
                ball.Center = new Vector2(random.Next(50, BoardWidth-50), random.Next(50, BoardHeight-50));
                while(tmp) { 
                    g = random.Next(-2, 2);
                    h = random.Next(-2, 2);
                    if (g != 0 && h != 0) { tmp = false; }
                }
                ball.MoveDirection = new Vector2(g*random.Next(1, 5), h*random.Next(1, 5));
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
                        try
                        {
                            _ct.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                        ball.Move();
                        Thread.Sleep(5);
                    }
                }
                );
                _tasks.Add(task);
            }
        }
        public void Stop()
        {
            _cts.Cancel();
            _tasks.Clear();
            _balls.Clear();
        }
    }
}