using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimInterConstruct
{
    public interface IClonable<T> where T : IClonable<T>
    {
        T Clone();
    }

    public class Point : IClonable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point other)
        {
            X = other.X;
            Y = other.Y;
        }

        public Point Clone()
        {
            return new Point(this);
        }
    }

    public class Rectangle : IClonable<Rectangle>
    {
        public Point UpperLeft { get; set; }
        public Point LowerRight { get; set; }

        public Rectangle(Point upperLeft, Point lowerRight)
        {
            UpperLeft = upperLeft;
            LowerRight = lowerRight;
        }

        public Rectangle(Rectangle other)
        {
            UpperLeft = new Point(other.UpperLeft);
            LowerRight = new Point(other.LowerRight);
        }

        public Rectangle Clone()
        {
            return new Rectangle(this);
        }
    }

}


