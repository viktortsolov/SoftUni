using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; private set; }
        public double Height { get; private set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return (2 * Width) + (2 * Height);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
