using Mindbox.Circle;
using Mindbox.Core;
using Mindbox.Interfaces;
using Mindbox.Triangle;
using Moq;

namespace ShapeTests
{
    public class Tests
    {
        private static readonly int DIGITS_COUNT_AFTER_COMMA = 2;

        [Fact]
        public void CircleInvalidTest() => Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));

        [Fact]
        public void CircleSquareTest()
        {
            var creator = InitShapeFactoryMoq(radius:10).Object;

            IShape circle = creator.GetShape(10);

            double expectedSquare = 314.16;

            Assert.Equal(expectedSquare, ShapeProcessor.CalculateSquare(circle, DIGITS_COUNT_AFTER_COMMA));
        }

        [Fact]
        public void TriangleInvalideSidesTest()
        {
            //invalid sides
            Assert.Throws<ArgumentOutOfRangeException>(() => InitShapeFactoryMoq(new double[] { -2, 0, 0 }));
            Assert.Throws<ArgumentOutOfRangeException>(() => InitShapeFactoryMoq(new double[] { 0, -2, 0 }));
            Assert.Throws<ArgumentOutOfRangeException>(() => InitShapeFactoryMoq(new double[] { 0, 0, -2 }));
            Assert.Throws<ArgumentOutOfRangeException>(() => InitShapeFactoryMoq(new double[] { -2, -2, -2 }));

            //triangle not exists
            Assert.Throws<ArgumentOutOfRangeException>(() => InitShapeFactoryMoq(new double[] { -2, -2, -2 }));
        }

        [Fact]
        public void TriangleSquareTest()
        {
            var creator = InitShapeFactoryMoq(new double[] { 1, 2, 2 }).Object;

            IShape triangle = creator.GetShape(1, 2, 2);

            double square = 0.97;

            Assert.Equal(square, ShapeProcessor.CalculateSquare(triangle, DIGITS_COUNT_AFTER_COMMA));
        }

        [Fact]
        public void RightTriangleTest()
        {
            var creator = InitShapeFactoryMoq(new double[] { 3, 4, 5 }).Object;

            if (creator.GetShape(3, 4, 5) is Triangle triangle)
                Assert.True(triangle.IsRightAngledTriangle);
            else
                Assert.Fail();
        }

        [Fact]
        public void NotRightTriangleTest()
        {
            var creator = InitShapeFactoryMoq(new double[] { 1, 1, 1 }).Object;

            if (creator.GetShape(1, 1, 1) is Triangle triangle)
                Assert.False(triangle.IsRightAngledTriangle);
            else
                Assert.Fail();
        }

        [Fact]
        public void ValidDigitsAfterCommaTest()
        {
            var creator = InitShapeFactoryMoq(new double[] { 1, 2, 2 }).Object;

            IShape triangle = creator.GetShape(1, 2, 2);

            double square = 1.00;
            Assert.Equal(square, Math.Floor(ShapeProcessor.CalculateSquare(triangle)));
        }

        [Fact]
        public void NullableShapeProcessorTest() =>
            Assert.Throws<ArgumentNullException>(() => ShapeProcessor.CalculateSquare(default));

        [Fact]
        public void CreatorReturnValidTypeOfShapeTest()
        {
            var creator = InitShapeFactoryMoq(new double[] { 1, 1, 2 }, 1).Object;

            IShape triangle = creator.GetShape(1, 1, 2);
            IShape circle = creator.GetShape(1);

            Assert.True(triangle is Triangle);
            Assert.False(triangle is Circle);
            Assert.False(circle is Triangle);
            Assert.True(circle is Circle);
        }


        private Mock<IShapeFactory> InitShapeFactoryMoq(double[] sides = null, double? radius = null)
        {
            var mockFactory = new Mock<IShapeFactory>();

            if(radius!= null)
            mockFactory.Setup(x => x.GetShape(radius.Value)).Returns(new Circle(radius.Value));

            if(sides!= null)
            mockFactory.Setup(x => x.GetShape(sides[0], sides[1], sides[2])).Returns(new Triangle(sides[0], sides[1], sides[2]));

            return mockFactory;
        }

    }
}