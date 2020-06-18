using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryPacking.Models
{
    public interface IRestangle
    {
        public uint Height { get; set; }
        public uint Width { get; set; }
        public uint Area { get; }

    }
}
