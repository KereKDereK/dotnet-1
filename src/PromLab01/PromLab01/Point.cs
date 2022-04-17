using System;
using System.Xml.Serialization;

namespace Lab01
{

    [Serializable]
    [XmlRoot("Point")]
    public struct Point
    {
        [XmlElement("X")]
        public double X
        {
            get;
        }
        [XmlElement("Y")]
        public double Y
        {
            get;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        new public string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        static public double GetLength(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

    }
}
