using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMdataLayer
{
        public class Vehicles
        {
        public int Id { get; set; }
            public string? PlateNumber { get; set; }
            public string? Brand { get; set; }
            public string? Model { get; set; }
            public int Year { get; set; }
            public decimal PricePerDay { get; set; }
            public bool IsAvailable { get; set; }
        }
    }

