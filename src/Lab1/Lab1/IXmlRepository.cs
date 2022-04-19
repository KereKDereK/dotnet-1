using System.Collections.Generic;

namespace Lab1
{
    public interface IXmlRepository
    {
        void AddShape(int index, Shape shape);

        void DeleteShape(int index);

        void DeleteAll();

        List<Shape> GetAll();

    }
}