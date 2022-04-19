using System.Xml.Serialization;

namespace Lab1
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Rectangle GetBorders();
        public abstract override string ToString();
    }
}
