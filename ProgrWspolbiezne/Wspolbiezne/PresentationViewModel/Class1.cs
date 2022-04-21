using System.ComponentModel;
using System.Runtime.CompilerServices;
using PresentationModel;

namespace PresentationViewModel
{
    public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ModelAbstractApi modelAbstractAPI;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
