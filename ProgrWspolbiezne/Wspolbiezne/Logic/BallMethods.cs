using System;
using System.Drawing;

namespace Logic
{
    public class BallMethods
    {

        private Point _center;
        private Point _moveDirection;
        private readonly int _radius;

        public int Radius { get { return _radius; } }
        public Point Center { get { return _center; } }
        public Point MoveDirection { get { return _moveDirection; } }


        public BallMethods(int xPoint, int yPoint,int radius)
        {
            _center = new Point(xPoint, yPoint);
            _radius = radius;

        }

        public void newPoint()
        {
            Random random = new Random();
            _moveDirection = new Point(random.Next(-1, 2), random.Next(-1, 2));
        }

        public void Move(int topPosition, int rightPosition, int bottomPosition, int leftPosition)
        {
            while () 
            
            { /// warunki do zrobienia}

            _center.Offset(_moveDirection);
        }

    }
}
