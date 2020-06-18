using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace BinaryPacking
{
    public static class Extensions
    {
        public static Rectangle CloneTurned(this Rectangle rectangle)
        {
            return new Rectangle()
            {
                Width = rectangle.Height,
                Height = rectangle.Width,
                Fill = rectangle.Fill,
                HorizontalAlignment = rectangle.HorizontalAlignment,
                StrokeThickness = rectangle.StrokeThickness,
                Stroke = rectangle.Stroke
            };
        }
    }
}
