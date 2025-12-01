using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMdataLayer
{
        public class Rentals
        {
            public int RentalId { get; set; }

            public int CustomerId { get; set; }
            public Customers Customer { get; set; }

            public int Id { get; set; }
            public Vehicles Vehicle { get; set; }

            public DateTime RentDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public decimal TotalCost { get; set; }
        }
    }