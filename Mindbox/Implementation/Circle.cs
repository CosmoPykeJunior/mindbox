using Mindbox.Interfaces;

namespace Mindbox.Circle
{
    public class Circle : IShape
    {
        #region ctor
        public double Radius { get; }

        public Circle(double radius)
        {
            if(radius < 0)
                throw new ArgumentOutOfRangeException("Radius can't be smaller than 0");

            Radius = radius;
        }
        #endregion

        public double CalculateSquare() => Math.PI * Math.Pow(Radius, 2);
    }
}
