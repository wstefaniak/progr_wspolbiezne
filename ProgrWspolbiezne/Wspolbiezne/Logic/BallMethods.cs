using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public class BallMethods : INotifyPropertyChanged
    {
        private readonly Ball _ball;
        public Ball Ball { get { return _ball; } }
        public BallMethods(Ball ball)
        {
            _ball = ball;
            ball.PropertyChanged += BallPropertyChanged;
        }

        public float X
        {
            get { return _ball.X; }
            set
            {
                _ball.X = value;
                RaisePropertyChanged(nameof(_ball.X));
            }
        }
        public float Y
        {
            get { return _ball.Y; }
            set
            {
                _ball.Y = value;
                RaisePropertyChanged(nameof(_ball.Y));
            }
        }

        public int Radius
        {
            get { return _ball.Radius; }
        }

        public float DirectionX
        {
            get { return _ball.DirectionX; }
            set
            {
                _ball.DirectionX = value;
                RaisePropertyChanged(nameof(_ball.DirectionX));
            }
        }

        public float DirectionY
        {
            get { return _ball.DirectionY; }
            set
            {
                _ball.DirectionY = value;
                RaisePropertyChanged(nameof(_ball.DirectionY));
            }
        }

        public void BallPropertyChanged(object obj, PropertyChangedEventArgs args)
        {
            RaisePropertyChanged(nameof(_ball.Center));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}