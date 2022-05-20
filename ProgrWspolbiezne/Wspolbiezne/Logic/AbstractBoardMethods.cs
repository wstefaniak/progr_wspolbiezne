using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data;

namespace Logic
{
    public abstract class AbstractBoardMethods
    {
        public List<BallMethods> _balls;

        public static AbstractBoardMethods CreateBoard(DataAbstractApi _data = default)
        {
            return new BoardMethods(_data ?? DataAbstractApi.CreateApi());
        }
        public abstract int Height { get; }
        public abstract int Width { get; }
        public abstract void CreateBalls(int amount);
        public abstract void StartMove();
        public abstract void StopMove();
        public abstract ObservableCollection<Ball> Balls { get; }
        public abstract List<BallMethods> GetBalls();
    }

    
}