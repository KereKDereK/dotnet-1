using System;
using System.Xml.Serialization;

namespace Lab1
{
    public struct Point
    {
        [XmlElement("X")]
        public double X
        {
            get; init;
        }
        [XmlElement("Y")]
        public double Y
        {
            get; init;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        public static double GetLength(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

    }
}
