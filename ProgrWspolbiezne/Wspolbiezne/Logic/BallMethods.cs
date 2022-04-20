using System;

namespace Logic
{
    public class BallMethods
    {
      
       /// private readonly int _windowHeight;
       /// private readonly int _windowWidth;
        private readonly int _radius;


        public BallMethods(int radius)
        {
            _radius = radius;

        }

        public void CreateABall()
        {
            int xPoint = 0;
            int yPoint = 0;
            Random random = new Random();
            

        }

        public void GenerateBalls(int balls)
        {
            for (int i = 0; i < balls; balls++)
            {
                CreateABall(); 
            }
        }
    }
}
