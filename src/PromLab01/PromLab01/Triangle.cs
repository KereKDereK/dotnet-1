using System;
using System.Linq;
using System.Xml.Serialization;

namespace Lab01
{

    [Serializable]
    [XmlRoot("Triangle")]
    public class Triangle : Shape
    {
        [XmlElement("Points")]
        public Point A
        {
            get;
        }
        public Point B
        {
            get;
        }
        public Point C
        {
            get;
        }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Triangle()
        {
            A=  new Point(0, 0);
            B = new Point(1, 1);
            C = new Point(-1, 1);
        }

        private double MinX()
        {
            return Math.Min(Math.Min(A.X, B.X), C.X);
        }

        private double MinY()
        {
            return Math.Min(Math.Min(A.Y, B.Y), C.Y);
        }

        private double MaxX()
        {
            return Math.Max(Math.Max(A.X, B.X), C.X);
        }

        private double MaxY()
        {
            return Math.Max(Math.Min(A.Y, B.Y), C.Y);
        }

        override public double GetArea()
        {
            return Math.Sqrt(GetPerimeter()
                * (GetPerimeter() - Point.GetLength(A, B))
                * (GetPerimeter() - Point.GetLength(B, C))
                * (GetPerimeter() - Point.GetLength(C, A)));
        }

        override public double GetPerimeter()
        {
            return Point.GetLength(A, B)
                + Point.GetLength(B, C)
                + Point.GetLength(C, A);
        }

        override public Rectangle GetBorders()
        {
            return new Rectangle(new Point(MinX(), MinY()),
                new Point(MaxX(), MaxY()));
        }

        override public string ToString()
        {
            return "{" + A.ToString() + ";" + B.ToString()
                + ";" + C.ToString() + "}";
        }
    }
}
