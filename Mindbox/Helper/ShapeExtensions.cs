using Mindbox.Interfaces;

namespace Mindbox.Helper
{
    public static class ShapeExtensions
    {
        public static double CalculateSquareWithRounding(this IShape shape, int? digitsCountAfterComma = null) =>
           Math.Round(shape.CalculateSquare(), digitsCountAfterComma ?? 0);
    }
}
