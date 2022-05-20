using Logic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentationModel
{
    public class BallModel : INotifyPropertyChanged
    {
        private float _center_X;
        private float _center_Y;
        private int _radius;

        public BallModel(BallMethods ballMethods)
        {
            ballMethods.PropertyChanged += BallPropertyChanged;
            _center_X = ballMethods.X;
            _center_Y = ballMethods.Y;
            _radius = ballMethods.Radius;

        }
        
        public float Center_X
        {
            get => _center_X;
            set
            {
                _center_X = value;
                RaisePropertyChanged(nameof(Center_X));
            }
        }

        public float Center_Y
        {
            get => _center_Y;
            set
            {
                _center_Y = value;
                RaisePropertyChanged(nameof(Center_Y));
            }
        }

        public int Radius { get => _radius*2; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void BallPropertyChanged(object obj, PropertyChangedEventArgs args)
        {
            BallMethods ballMethods = (BallMethods)obj;
            Center_X = ballMethods.X;
            Center_Y = ballMethods.Y;
            RaisePropertyChanged(nameof(Center_X));
            RaisePropertyChanged(nameof(Center_Y));
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
