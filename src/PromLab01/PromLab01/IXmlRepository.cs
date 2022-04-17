using System.Collections.Generic;

namespace Lab01
{
    public interface IXmlRepository
    {
        string StorageFileName { get; set; }
        List<Shape> Shapes { get; set; }
        void AddRectangle(int index, Point firstPoint, Point lastPoint);
        void AddCircle(int index, Point centr, double radius);
        void AddTriangle(int index, Point a, Point b, Point c);
        void AddShape(int index, Shape figure);
        int CompareArea(int index1, int index2);
        int ComparePerimeter(int index1, int index2);
        void DeleteShape(int index);
        void DeleteAll();
        void OpenFile(string path);
        void SaveFile(string path);
        double Sum();
        double SumLinq();
        bool CheckIndex(int index);
    }
}