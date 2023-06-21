using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoringPlatformer2
{
    internal class Door
    {
        public int x, y, index;
        public int width = 30;
        public int height = 30;
        public Rectangle ellipse, rectangle;
        List<Point> positions;

        public Door (int _x, int _y)
        {
            x = _x;
            y = _y;
            ellipse = new Rectangle (x, y, width, 30);
            rectangle = new Rectangle (x, y + 15, width, 30);
        }

        public Door (int _x, int _y, List<Point> _positions)
        {
            x = _x;
            y = _y;
            positions = _positions;
            index = 0;
        }

        public void Move()
        {
            index++;

            if(positions != null && index < positions.Count)
            {
                x = positions[index].X;
                y = positions[index].Y;
            }
        }
    }
}
