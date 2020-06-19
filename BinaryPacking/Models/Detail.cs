using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace BinaryPacking.Models
{
    public class Detail : IRestangle
    {
        /// <summary>
        /// Detail class to all calculations
        /// </summary>

        public uint Height { get ; set; }
        public uint Width { get ; set ; }

        public uint Area { get => Height * Width; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Rectangle View { get; set; }

       
    }
}
