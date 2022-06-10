using System.Collections.ObjectModel;

namespace Data
{
    public class DataApi : DataAbstractApi
    {
        private Board _board = new Board();
        public DataApi() { }

        public override int Width { get => _board.Width; }
        public override int Height { get => _board.Height; }
        public override void CreateBalls(int amount)
        {
            _board = new Board();
            _board.CreateBalls(amount);
        }

        public override void StartMove()
        {
            _board.Start();
        }

        public override void StopMove()
        {
            if(_board != null)
            {
                _board.Stop();
            }
        }

        public override Board GetBoard()
        {
            return _board;
        }

        public override ObservableCollection<Ball> GetBalls()
        {
            return _board.Balls;
        }

        public override object FileLocker
        {
            get => _board.FileLocker;
        }
        public override string FileName
        {
            get => _board.FileName;
        }
    }
}
