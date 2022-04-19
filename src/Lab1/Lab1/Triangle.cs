using System;
using System.Xml.Serialization;

namespace Lab1
{
    public class Triangle : Shape
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
        [XmlElement("ThirdPoint")]
        public Point C
        {
            get; init;
        }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Triangle()
        {
            A = new Point(0, 0);
            B = new Point(1, 1);
            C = new Point(-1, 1);
        }

        public override double GetArea()
        {
            return Math.Sqrt(GetPerimeter()
                * (GetPerimeter() - Point.GetLength(A, B))
                * (GetPerimeter() - Point.GetLength(B, C))
                * (GetPerimeter() - Point.GetLength(C, A)));
        }

        public override double GetPerimeter()
        {
            return Point.GetLength(A, B)
                + Point.GetLength(B, C)
                + Point.GetLength(C, A);
        }

        public override Rectangle GetBorders()
        {
            return new Rectangle(new Point(Math.Min(Math.Min(A.X, B.X), C.X),
                Math.Min(Math.Min(A.Y, B.Y), C.Y)),
                new Point(Math.Max(Math.Max(A.X, B.X), C.X),
                Math.Max(Math.Min(A.Y, B.Y), C.Y)));
        }

        public override string ToString()
        {
            return "{" + A.ToString() + ";" + B.ToString()
                + ";" + C.ToString() + "}";
        }
    }
}
