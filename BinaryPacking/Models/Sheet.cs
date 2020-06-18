using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryPacking.Models
{
    public class Sheet : IRestangle
    {
        public uint Height { get ; set ; }
        public uint Width { get ; set ; }

        public uint Area { get => Height * Width; }

        public List<Detail> DetailsUnpacked { get; set; } 

        public List<Detail> DetailsPacked { get; set; }

        public Sheet()
        {
            DetailsUnpacked = new List<Detail>();
            DetailsPacked = new List<Detail>();
        }

        

    }
}
