using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Lab01
{
    public class XmlShapeRepository : IXmlRepository
    {
        public string StorageFileName
        {
            get; set;
        } = "shapes.xml";

        public List<Shape> Shapes
        {
            get; set;
        }

        public XmlShapeRepository() { }
        public XmlShapeRepository(List<Shape> shapes)
        {
            Shapes = shapes;
        }
        public bool CheckIndex(int index)
        {
            if (Shapes == null)
            {
                return false;
            }
            return (index < Shapes.Count) && (index >= 0);
        }

        public void DeleteShape(int index)
        {
            if (CheckIndex(index))
                Shapes.RemoveAt(index);
        }

        public void AddShape(int index, Shape figure)
        {
            if (Shapes.Count != index)
            {
                DeleteShape(index);
            }
            Shapes.Insert(index, figure);
        }

        public void AddRectangle(int index, Point a, Point b)
        {
            AddShape(index, new Rectangle(a, b));
        }

        public void AddCircle(int index, Point center, double radius)
        {
            AddShape(index, new Circle(center, radius));
        }

        public void AddTriangle(int index, Point a, Point b, Point c)
        {
            AddShape(index, new Triangle(a, b, c));
        }

        public int CompareArea(int index1, int index2)
        {
            if (Shapes[index1].GetArea() > Shapes[index2].GetArea())
                return index1;
            else return index2;
        }

        public int ComparePerimeter(int index1, int index2)
        {
            if (Shapes[index1].GetPerimeter() > Shapes[index2].GetPerimeter())
                return index1;
            else return index2;
        }

        public void DeleteAll()
        {
            Shapes.RemoveRange(0, Shapes.Count);
        }
        public void OpenFile(string path)
        {
            if (Shapes != null)
                return;

            if (!File.Exists(StorageFileName))
            {
                Shapes = new List<Shape>();
                return;
            }

            try
            {
                XmlSerializer formatter = new(typeof(List<Shape>));
                FileStream stream = new(path, FileMode.OpenOrCreate);
                Shapes = (List<Shape>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                Console.Write("File can't be opened\n");
            }
        }
        public void SaveFile(string path)
        {
            try
            {
                XmlSerializer formatter = new(typeof(List<Shape>));
                FileStream stream = new(path, FileMode.Create);
                formatter.Serialize(stream, Shapes);
                stream.Close();
            }
            catch (Exception)
            {
                Console.Write("File can't be saved\n");
            }

        }

        public double Sum()
        {
            double sum = 0;
            foreach (Shape figure in Shapes)
            {
                sum += figure.GetArea();
            }
            return sum;
        }

        public double SumLinq()
        {
            return Shapes.Sum(f => f.GetArea());
        }
    }
}
