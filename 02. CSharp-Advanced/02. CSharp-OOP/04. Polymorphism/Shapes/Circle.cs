using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private const double pi = Math.PI;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalculateArea()
        {
            return pi * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return pi * 2 * Radius;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
