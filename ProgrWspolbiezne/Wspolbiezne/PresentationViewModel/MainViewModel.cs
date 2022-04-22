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
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public MainViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            _height = ModelLayer.Height;
            _width = ModelLayer.Width;
            Balls = ModelLayer.Balls(_amount);
            StartCommand = new RelayCommand(() => Start());
            StopCommand = new RelayCommand(() => Stop());
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
        }

        private void Stop()
        {
            ModelLayer.StopMove();
        }
    }
}
