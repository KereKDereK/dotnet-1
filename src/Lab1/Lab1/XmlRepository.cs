using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1
{
    public class XmlShapeRepository : IXmlRepository
    {
        private readonly string StorageFileName = "shapes.xml";

        private List<Shape>? Shapes;

        public XmlShapeRepository() { }

        public void AddShape(int index, Shape shape)
        {
            OpenFile(StorageFileName);
            if (index > Shapes!.Count)
                Shapes!.Add(shape);
            else
                Shapes!.Insert(index, shape);
            SaveFile(StorageFileName);
        }

        public void DeleteShape(int index)
        {
            OpenFile(StorageFileName);
            if (index <= Shapes!.Count)
                Shapes!.RemoveAt(index);
            SaveFile(StorageFileName);
        }

        public List<Shape> GetAll()
        {
            OpenFile(StorageFileName);
            return Shapes!;
        }

        public void DeleteAll()
        {
            OpenFile(StorageFileName);
            Shapes!.RemoveRange(0, Shapes.Count);
            SaveFile(StorageFileName);
        }

        private void OpenFile(string path)
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
                Shapes = (List<Shape>)formatter.Deserialize(stream)!;
                stream.Close();
            }
            catch (Exception)
            {
                Console.Write("File can't be opened\n");
            }
        }
        private void SaveFile(string path)
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
    }
}
