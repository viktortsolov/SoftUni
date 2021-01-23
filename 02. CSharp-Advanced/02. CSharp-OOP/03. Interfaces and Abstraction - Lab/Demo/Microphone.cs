using Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Microphone : IPrice
    {
        public decimal Price { get; set; }
        public string Model { get; set; }
        public bool IsDesperatelyNeeded { get; set; }
    }
}
