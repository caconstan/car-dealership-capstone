using System;
using System.Collections.Generic;

namespace GC_Car_Dealership_Capstone.Models
{
    public partial class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}
