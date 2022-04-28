using System.Windows.Input;
using PresentationModel;
using System.Collections;

namespace PresentationViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModelAbstractApi ModelLayer;
        private readonly int _width, _height;
        private int _amount;
        private IList _balls;
        private bool _isStopEnabled;
        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        public MainViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            _height = ModelLayer.Height;
            _width = ModelLayer.Width;
            Balls = ModelLayer.Balls(_amount);
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
            ModelLayer.Balls(_amount);
            ModelLayer.StartMove();
            _isStopEnabled = true;
            StopCommand.RaiseCanExecuteChanged();
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
