using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public byte[]? Image { get; set; }
    }
}
