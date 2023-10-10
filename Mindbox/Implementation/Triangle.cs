using Mindbox.Interfaces;

namespace Mindbox.Triangle
{
    public class Triangle : IShape
    {
        #region ctor
        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }

        public bool IsRightAngledTriangle { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {

            ValidateSide(sideA, nameof(SideA));
            ValidateSide(sideB, nameof(SideB));
            ValidateSide(sideC, nameof(SideC));

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            ValideTriangle();

            IsRightAngledTriangle = IsRight();
        }
        #endregion

        public double CalculateSquare()
        {
            double semiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        #region private methods
        private double GetPerimeter() => SideA + SideB + SideC;

        private static void ValidateSide(double sideValue, string sideName)
        {
            if (sideValue < 0)
                throw new ArgumentOutOfRangeException($"Side is incorrect {sideName}");
        }

        private void ValideTriangle()
        {
            if (SideA + SideB >= SideC)
                if (SideB + SideC >= SideA)
                    if (SideC + SideA >= SideB)
                        return;

            throw new ArgumentOutOfRangeException("The sides of the triangle are wrong");

        }

        private bool IsRight() =>
           Math.Pow(SideA, 2) + Math.Pow(SideB, 2) == Math.Pow(SideC, 2) ||
           Math.Pow(SideC, 2) + Math.Pow(SideA, 2) == Math.Pow(SideB, 2) ||
           Math.Pow(SideB, 2) + Math.Pow(SideC, 2) == Math.Pow(SideA, 2);
        #endregion
    }
}
