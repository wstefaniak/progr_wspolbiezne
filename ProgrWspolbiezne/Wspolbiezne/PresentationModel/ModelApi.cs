using System.Collections.ObjectModel;
using Logic;

namespace PresentationModel
{
    internal class ModelApi : ModelAbstractApi
    {
        private readonly BoardMethods Board = new BoardMethods();
        public override int Width => BoardMethods.BoardWidth;
        public override int Height => BoardMethods.BoardHeight;

        public override ObservableCollection<BallMethods> Balls(int amount)
        {
            Board.CreateBalls(amount);
            return Board.Balls;
        }

        public override void StartMove()
        {
            Board.Start();
        }

        public override void StopMove()
        {
            Board.Stop();
        }
    }
}
