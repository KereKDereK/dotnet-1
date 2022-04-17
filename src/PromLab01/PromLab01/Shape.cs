using System;
using System.Xml.Serialization;

namespace Lab01
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    [Serializable]
    abstract public class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Rectangle GetBorders();
        new public abstract string ToString();
    }
}
