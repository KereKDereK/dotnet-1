using System;
using System.Xml.Serialization;

namespace Lab01
{

    [Serializable]
    [XmlRoot("Rectangle")]
    public class Rectangle : Shape
    {
        [XmlElement("First_point")]
        public Point A
        {
            get;
        }
        [XmlElement("Second_point")]
        public Point B
        {
            get;
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
            A = new Point(0,0);
            B = new Point(1,1);
        }

        override public double GetArea()
        {
            return Math.Abs(B.X - A.X) * Math.Abs(B.Y - A.Y);
        }

        override public double GetPerimeter()
        {
            return 2 * Math.Abs(B.X - A.X) + 2 * Math.Abs(B.Y - A.Y);
        }

        override public Rectangle GetBorders()
        {
            return new Rectangle(A, B);
        }

        override public string ToString()
        {
            return "{" + A.ToString() + ";" + B.ToString() + "}";
        }
    }
}
