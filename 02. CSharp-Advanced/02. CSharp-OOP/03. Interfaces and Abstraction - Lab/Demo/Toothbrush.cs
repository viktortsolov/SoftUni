using System;
using System.Collections.Generic;
using System.Text;

using Demo.Contracts;

namespace Demo
{
    class Toothbrush : IPrice
    {
        public decimal Price { get; set; }
        public string Model { get; set; }
        public int Whitening { get; set; }
    }
}
