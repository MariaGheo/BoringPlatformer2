using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringPlatformer2
{
    internal class Obstacle
    {
        public int x, y, min, max;
        public int speed = 0;
        public int width = 30;
        public int height = 10;
        public bool vertical;

        public Obstacle(int _x, int _y, int _speed, bool _vertical, int _min, int _max)
        {
            x = _x;
            y = _y;
            speed = _speed;
            vertical = _vertical;
            min = _min;
            max = _max;
        }

        public void Move()
        {
            if (speed != 0)
            {
                if (vertical)
                {
                    int newY = y + speed; //used to check if the platform will go out of the intended range if we just add the speed

                    if (newY >= max)
                    {
                        y = max;
                        speed *= -1; //changes platform direction
                    }
                    else if (newY <= min)
                    {
                        y = min;
                        speed *= -1; //changes platform direction
                    }
                    else
                    {
                        y += speed;
                    }
                }
                else
                {
                    int newX = x + speed; //used to check if the platform will go out of the intended range if we just add the speed

                    if (newX >= max)
                    {
                        x = max;
                        speed *= -1; //changes platform direction
                    }
                    else if (newX <= min)
                    {
                        x = min;
                        speed *= -1; //changes platform direction
                    }
                    else
                    {
                        x += speed;
                    }
                }
            }
        }
    }
}