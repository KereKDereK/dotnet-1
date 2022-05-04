using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1
{
    public class XmlShapeRepository : IXmlRepository
    {
        private readonly string StorageFileName = "shapes.xml";

        private List<Shape>? _shapes;

        public XmlShapeRepository() { }

        public void AddShape(int index, Shape shape)
        {
            var shapes = OpenFile(StorageFileName);
            if (index > shapes.Count)
                shapes.Add(shape);
            else
                shapes.Insert(index, shape);
            SaveFile(StorageFileName);
        }

        public void DeleteShape(int index)
        {
            var shapes = OpenFile(StorageFileName);
            if (index <= shapes.Count)
                shapes.RemoveAt(index);
            SaveFile(StorageFileName);
        }

        public List<Shape> GetAll()
        {
            return OpenFile(StorageFileName);
        }

        public void DeleteAll()
        {
            var shapes = OpenFile(StorageFileName);
            shapes.RemoveRange(0, shapes.Count);
            SaveFile(StorageFileName);
        }

        private List<Shape> OpenFile(string path)
        {
            if (_shapes is not null)
                return _shapes;

            if (!File.Exists(StorageFileName))
            {
                _shapes = new List<Shape>();
                return _shapes;
            }

            try
            {
                var formatter = new XmlSerializer(typeof(List<Shape>));
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                _shapes = (List<Shape>?)formatter.Deserialize(stream) ?? throw new Exception("Failed to deserialize");
                return _shapes;
            }
            catch
            {
                throw new Exception("File can't be opened");
            }
        }
        private void SaveFile(string path)
        {
            try
            {
                XmlSerializer formatter = new(typeof(List<Shape>));
                using var stream = new FileStream(path, FileMode.Create);
                formatter.Serialize(stream, _shapes);
            }
            catch
            {
                throw new Exception("File can't be saved");
            }
        }
    }
}
