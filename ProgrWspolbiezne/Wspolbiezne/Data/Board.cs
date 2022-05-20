using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;


namespace Data
{
    public class Board
    {
        public static int _width = 830;
        public static int _height = 700;
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();
        private List<Task> _tasks = new List<Task>();
        public CancellationTokenSource _cts;
        public CancellationToken _ct;
        private object _locker = new object();

        public Board()
        {
        }
        public Board GetBoard() { return this; }
        public int Width { get => _width; }

        public int Height { get => _height; }

        public ObservableCollection<Ball> Balls { get => _balls; }

        public int TaskAmount { get => _tasks.Count; }

        public void CreateBalls(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (Balls.Count == 0)
            {
                _tasks.Clear();
                Balls.Clear();
            }

            if(amount > 0)
            {
                Random random = new Random();
                _cts = new CancellationTokenSource();
                _ct = _cts.Token;
                for (int i = 0; i < amount; i++)
                {
                    int g, h;
                    Ball ball = new Ball();
                    ball.Center = new Vector2(random.Next(50, _width - 50), random.Next(50, _height - 50));
                    ball.Mass = (float)random.NextDouble();
                    do
                    {
                        g = random.Next(-2, 2);
                        h = random.Next(-2, 2);
                    } while (g == 0 || h == 0);
                    ball.MoveDirection = new Vector2(g * random.Next(1, 3), h * random.Next(1, 3));
                    _balls.Add(ball);
                }
            }
        }

        public void Start()
        {
            foreach (Ball ball in _balls)
            {
                Task task = Task.Run(async() =>
                {
                    while (true)
                    {
                        await Task.Delay(10);
                        lock (_locker)
                        {
                            ball.Move();
                        }
                        ball.Move();
                        try { _ct.ThrowIfCancellationRequested(); }
                        catch (OperationCanceledException) { break; }
                    }
                });
                _tasks.Add(task);
            }
        }

        public void Stop()
        {
            if (!_cts.IsCancellationRequested && _cts != null)
            {
                _cts.Cancel();
                _tasks.Clear();
                _balls.Clear();
            }
            
        }
    }
}
