using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace BoringPlatformer2
{
    internal class Player
    {
        public int x, y;
        public int jumpCount = 0;
        public int width = 20;
        public int height = 20;
        public int xSpeed = 7;
        public bool inAir = false;
        public Rectangle rectangle;

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
            rectangle = new Rectangle(x, y, width, height);
        }

        public void Move(bool left, bool right, bool jumping)
        {
            if (left)
            {
                x -= xSpeed;
                
                if (x < 0)
                {
                    x = 0;
                }
            }

            if (right)
            {
                x += xSpeed;

                if (x + width > 760)
                {
                    x = 760 - width;
                }
            }
            
            if (inAir)
            {
                y += Form1.jumpYSpeed[jumpCount];
                jumpCount++;
            }
            else if (jumping)
            {
                inAir = true;
                y += Form1.jumpYSpeed[0];
                jumpCount = 1;
            }

            rectangle = new Rectangle(x, y, width, height);
        }

        public bool IntersectsWith(Door door)
        {
            Rectangle doorRectangle = new Rectangle(door.x, door.y, door.width, door.height);

            return rectangle.IntersectsWith(doorRectangle);
        }

        public bool IntersectsWith(Obstacle obstacle)
        {
            Rectangle obstacleRectangle = new Rectangle(obstacle.x, obstacle.y, obstacle.width, obstacle.height);

            return rectangle.IntersectsWith(obstacleRectangle);
        }

        public bool IsOnTopOf(Platform platform)
        {
            return x + width > platform.x && x < platform.x + platform.width && y == platform.y - height;
        }

        public bool IsAbove(Platform platform)
        {
            Rectangle abovePlatform = new Rectangle(platform.x, 0, platform.width, platform.y);

            return rectangle.IntersectsWith(abovePlatform);
        }

        public bool IsBelow(Platform platform)
        {
            Rectangle belowPlatform = new Rectangle(platform.x, platform.y, platform.width, 400);

            return rectangle.IntersectsWith(belowPlatform);
        }
    }
}
