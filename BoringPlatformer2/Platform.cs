using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoringPlatformer2
{
    internal class Platform
    {
        public int x, y, width, height;
        public Rectangle edge;
        int minX, maxX;
        int speed = 0;
        int fallCount = -1;
        public bool willFall = false;
        public bool visible = true;

        public Platform(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            edge = new Rectangle(x, y - 2, width, 2);
        }

        public Platform(int _x, int _y, int _width, int _height, int _speed, int _minX, int _maxX)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            minX = _minX;
            maxX = _maxX;
            edge = new Rectangle(x, y - 1, width, 1);
        }

        public void Fall() //makes the platform start falling
        {
            if (willFall)
            {
                fallCount = 0;
            }
        }

        public void Move() //makes the platform move
        {
            if (fallCount != -1)
            {
                if(y > 400)
                {
                    fallCount = -1;
                }
                else
                {
                    y += Form1.jumpYSpeed[8 + fallCount];
                    fallCount++;
                }
            }
            else if (speed != 0)
            {
                int newX = x + speed; //used to check if the platform will go out of the intended range if we just add the speed

                if (newX >= maxX)
                {
                    x = maxX;
                    speed *= -1; //changes platform direction
                }
                else if (newX <= minX)
                {
                    x = minX;
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
