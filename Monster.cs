using PJT250217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Monster : GameObject
    {
        private Random rand = new Random();

        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 5;
            isTrigger = true;
        }

        private double elapsedTime = 0.0;

        public override void Update()
        {
            if (elapsedTime > 500.0f)
            {
                elapsedTime = 0.0f;
                int Direction = rand.Next(0, 4);
                if (Direction == 0)
                {
                    if (!PredictCollision(X, Y - 1))
                    {
                        Y--;
                    }
                }
                if (Direction == 1)
                {
                    if (!PredictCollision(X, Y + 1))
                    {
                        Y++;
                    }
                }
                if (Direction == 2)
                {
                    if (!PredictCollision(X - 1, Y))
                    {
                        X--;
                    }
                }
                if (Direction == 3)
                {
                    if (!PredictCollision(X + 1, Y))
                    {
                        X++;
                    }
                }
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }
}