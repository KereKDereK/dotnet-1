using System;
using System.Xml.Serialization;

namespace Lab1
{
    public class Circle : Shape
    {
        [XmlElement("Center")]
        public Point Center
        {
            get; init;
        }
        [XmlElement("Radius")]
        public double Radius
        {
            get; init;
        }
        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }
        public Circle()
        {
            Radius = 1;
            Center = new Point(0, 0);
        }
        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override Rectangle GetBorders()
        {
            return new Rectangle(Center, Radius);
        }

        public override string ToString()
        {
            return "{" + Center.ToString() + ";" + "R: " + Radius;
        }

    }
}
