using System.Collections.ObjectModel;
using Logic;

namespace PresentationModel
{
    internal class ModelApi : ModelAbstractApi
    {
        private readonly AbstractBoardMethods board;
        public override int Width => board.Width;
        public override int Height => board.Height;
        public ModelApi(AbstractBoardMethods abstractBoardMethods)
        {
            board = abstractBoardMethods;
        }

        public override ObservableCollection<BallModel> CreateBalls(int amount)
        {
            board.CreateBalls(amount);
            ballModel.Clear();
            foreach(BallMethods ball in board.GetBalls())
            {
                ballModel.Add(new BallModel(ball));
            }
            return ballModel;
        }

        public override void StartMove()
        {
            board.StartMove();
        }

        public override void StopMove()
        {
            board?.StopMove();
            ballModel?.Clear();
        }
    }
}
