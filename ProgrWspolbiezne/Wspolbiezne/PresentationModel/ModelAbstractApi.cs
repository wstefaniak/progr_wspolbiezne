using System.Collections.ObjectModel;
using Logic;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        protected ObservableCollection<BallModel> ballModel = new ObservableCollection<BallModel>();
        public abstract ObservableCollection<BallModel> CreateBalls(int amount);
        public abstract void StartMove();
        public abstract void StopMove();

        public static ModelAbstractApi CreateApi(AbstractBoardMethods abstractBoardMethods = default)
        {
            return new ModelApi(abstractBoardMethods ?? AbstractBoardMethods.CreateBoard());
        }

        public ObservableCollection<BallModel> Balls
        {
            get => ballModel;
            set => ballModel = value;
        }
    }
}