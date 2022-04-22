using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class BallMethods : INotifyPropertyChanged
    {
        private Vector2 _center;
        private Vector2 _moveDirection;

        public BallMethods()
        {

        }

        public float X { get => _center.X; }
        public float Y { get => _center.Y; }
        public double Radius { get; } = 35;

        public Vector2 Center
        {
            get => _center;
            set => _center = value;
        }

        public Vector2 MoveDirection
        {
            get => _moveDirection;
            set => _moveDirection = value;
        }

        public void Move()
        {
            Center += new Vector2(_moveDirection.X, _moveDirection.Y);
            if (Center.X < Radius || Center.X > BoardMethods.BoardWidth)
            {
                _moveDirection.X *= -1;
            }
            if (Center.Y < Radius || Center.Y > BoardMethods.BoardHeight)
            {
                _moveDirection.Y *= -1;
            }
            RaisePropertyChanged(nameof(X));
            RaisePropertyChanged(nameof(Y));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}