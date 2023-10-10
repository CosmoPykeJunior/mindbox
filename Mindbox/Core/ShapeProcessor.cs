using Mindbox.Interfaces;

namespace Mindbox.Core
{
    public static class ShapeProcessor
    {
        public static double CalculateSquare(IShape shape, int? digitsCountAfterComma = null)
        {
            if (shape == null)
                throw new ArgumentNullException("Shape can't be null");

            return  Math.Round(shape.CalculateSquare(), digitsCountAfterComma ?? 0);
        }
    }
}
