using Mindbox.Circle;
using Mindbox.Core;
using Mindbox.Triangle;

namespace ShapeTests
{


    public class Tests
    {

        private static readonly int DIGITS_COUNT_AFTER_COMMA = 2;

        [Test]
        public void CircleInvalidTest() => Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));

        [Test]
        public void CircleSquareTest()
        {
            Circle circle = new(10);
            double expectedSquare = 314.16;

            Assert.That(expectedSquare, Is.EqualTo(ShapeProcessor.CalculateSquare(circle, DIGITS_COUNT_AFTER_COMMA)));
        }

        [Test]
        public void TriangleInvalideSidesTest()
        {
            //invalid sides
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -2, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, -2, -2));

            //triangle not exists
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 1, 4));
        }

        [Test]
        public void TriangleSquareTest()
        {
            var triangle = new Triangle(1, 2, 2);

            double square = 0.97;

            Assert.That(square, Is.EqualTo(ShapeProcessor.CalculateSquare(triangle, DIGITS_COUNT_AFTER_COMMA)));
        }

        [Test]
        public void RightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.That(triangle.IsRightAngledTriangle, Is.True);
        }

        [Test]
        public void NotRightTriangleTest()
        {
            var triangle = new Triangle(1, 1, 1);

            Assert.That(triangle.IsRightAngledTriangle, Is.False);
        }

        [Test]
        public void ValidDigitsAfterCommaTest()
        {
            var triangle = new Triangle(2, 2, 2);
            double square = 2.00;
            Assert.That(square, Is.EqualTo(Math.Floor(ShapeProcessor.CalculateSquare(triangle))));
        }

        [Test]
        public void NullableShapeProcessorTest()
        {
            Assert.Throws<ArgumentNullException>(() => ShapeProcessor.CalculateSquare(default));
        }
    }
}