using System;
using System.Xml.Serialization;

namespace Lab1
{
    public class Rectangle : Shape
    {
        [XmlElement("FirstPoint")]
        public Point A
        {
            get; init;
        }
        [XmlElement("SecondPoint")]
        public Point B
        {
            get; init;
        }
        public Rectangle(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public Rectangle(Point a, double width)
        {
            A = a;
            B = new Point(a.X + width, a.Y - width);

        }
        public Rectangle()
        {
            A = new Point(0, 0);
            B = new Point(1, 1);
        }

        public override double GetArea()
        {
            return Math.Abs(B.X - A.X) * Math.Abs(B.Y - A.Y);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.Abs(B.X - A.X) + 2 * Math.Abs(B.Y - A.Y);
        }

        public override Rectangle GetBorders()
        {
            return new Rectangle(A, B);
        }

        public override string ToString()
        {
            return "{" + A.ToString() + ";" + B.ToString() + "}";
        }
    }
}
