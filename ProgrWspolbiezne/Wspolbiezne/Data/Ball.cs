using System;
using System.Numerics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        private Vector2 _center;
        private Vector2 _moveDirection;
        private float _mass;
        public int Radius { get; } = 25;
        
        public Vector2 Center
        {
            get => _center;
            set => _center = value;
        }

        public float X
        {
            get { return _center.X; }
            set { _center.X = value; }
        }
        public float Y
        {
            get { return _center.Y; }
            set { _center.Y = value; }
        }

        public Vector2 MoveDirection
        {
            get => _moveDirection;
            set => _moveDirection = value;
        }
        public float Mass
        {
            get => _mass;
            set => _mass = value;
        }

        public Ball() { }
        public Ball(Vector2 direction)
        {
            _center = direction;
        }


        public void Move()
        {
            _center += _moveDirection;
            RaisePropertyChanged(nameof(_center));
        }

        public float DirectionX
        {
            get => _moveDirection.X;
            set => _moveDirection.X = value;
        }

        public float DirectionY
        {
            get => _moveDirection.Y;
            set => _moveDirection.Y = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
