using System.Collections.ObjectModel;
using Logic;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract ObservableCollection<BallMethods> Balls(int balls);
        public abstract void StartMove();
        public abstract void StopMove();

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }
}