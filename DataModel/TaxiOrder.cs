using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TaxiOrder
    {
        public int Id { get; set; }
        public int PassengersNumber { get; set; }
        public string Place { get; set; }
        public Taxi TaxiUsed { get; set; }
        public DateTime OrderedAt { get; set; }
        public int TravelTime { get; set; }
        public int Rating { get; set; }
    }
}
