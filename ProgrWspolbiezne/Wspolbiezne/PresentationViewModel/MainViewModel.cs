using PresentationModel;
using System.Collections;

namespace PresentationViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ModelAbstractApi ModelLayer { get; set; }
        private readonly int _width, _height;
        private int _amount;
        private IList _balls;
        private bool _isStopEnabled;
        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }

        public MainViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            _width = ModelLayer.Width;
            _height = ModelLayer.Height;
            Balls = ModelLayer.CreateBalls(_amount);
            StartCommand = new RelayCommand(Start, CanStart);
            StopCommand = new RelayCommand(Stop, CanStop);
            _isStopEnabled = false;
        }
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged(nameof(Amount)); }
        }
        public IList Balls
        {
            get { return _balls; }
            set { _balls = value; RaisePropertyChanged(nameof(Balls)); }
        }
        private void Start()
        {
            if (_amount == 0)
            {
                ModelLayer.StopMove();
            }
            else
            {
                ModelLayer.CreateBalls(_amount);
                ModelLayer.StartMove();
                _isStopEnabled = true;
                StopCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanStart()
        {
            return _isStopEnabled == false;
        }

        private void Stop()
        {
            ModelLayer.StopMove();
            _isStopEnabled = false;
            StartCommand.RaiseCanExecuteChanged();
        }
        private bool CanStop()
        {
            return _isStopEnabled;
        }
    }
}
