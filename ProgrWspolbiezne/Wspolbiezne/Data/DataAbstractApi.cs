using System.Collections.ObjectModel;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract ObservableCollection<Ball> GetBalls();
        public abstract void CreateBalls(int amount);
        public abstract void StartMove();
        public abstract void StopMove();
        public abstract Board GetBoard();

        public abstract object FileLocker { get; }

        public abstract string FileName { get; }
        
        public static DataAbstractApi CreateApi()
                {
                    return new DataApi();
                }
    }
}
