using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CuteGame.Objects.Helper
{
    public struct Circle
    {
        public Circle(int x, int y, int radius)
        {
            Center = new Point(x, y);
            Radius = radius;
        }

        public Point Center { get; private set; }
        public int Radius { get; private set; }

    }
}
