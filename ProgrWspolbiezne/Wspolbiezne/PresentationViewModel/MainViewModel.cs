using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MainViewModel : Class1
    {
        public MainViewModel() : this(ModelAbstractApi.CreateApi())
        {

        }

        public MainViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radius = ModelLayer.Radius;
            StartCommand = new RelayCommand(OnStart, CanStart);
            StopCommand = new RelayCommand(OnStop, CanStop);
        }








    }
}
