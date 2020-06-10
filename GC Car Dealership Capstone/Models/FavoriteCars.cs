using System;
using System.Collections.Generic;

namespace GC_Car_Dealership_Capstone.Models
{
    public partial class FavoriteCars
    {
        public int Id { get; set; }
        public int Carid { get; set; }
        public string Userid { get; set; }

        // Properties below are set via API
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }
}
