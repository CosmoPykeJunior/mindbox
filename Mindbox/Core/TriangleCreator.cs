using Mindbox.Interfaces;

namespace Mindbox.Core
{
    public interface IShapeFactory
    {

        public IShape GetShape(double a, double b, double c);
        public IShape GetShape(double radius);
    }

    public class ShapeFactory : IShapeFactory
    {
        public IShape GetShape(double a, double b, double c) =>
            new Triangle.Triangle(a, b, c);

        public IShape GetShape(double radius) =>
            new Circle.Circle(radius);
    }
}

