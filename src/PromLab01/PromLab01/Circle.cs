using System;
using System.Xml.Serialization;

namespace Lab01
{

    [Serializable]
    [XmlRoot("Circle")]
    public class Circle : Shape
    {
        [XmlElement("Center")]
        public Point A
        {
            get;
        }
        [XmlElement("Radius")]
        public double Radius
        {
            get;
        }
        public Circle(Point a, double radius)
        {
            A = a;
            Radius = radius;
        }
        public Circle()
        {
            Radius = 5;
            A = new Point(0,0);
        }
        override public double GetArea()
        {
            return Radius * Radius * Math.PI;
        }

        override public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        override public Rectangle GetBorders()
        {
            return new Rectangle(A, Radius);
        }

        override public string ToString()
        {
            return "{" + A.ToString() + ";" + "R: " + Radius;
        }

    }
}
