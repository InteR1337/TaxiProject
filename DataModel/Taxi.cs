using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Taxi
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int PassengerSeats { get; set; }
        public DateTime UsedFrom { get; set; }
    }
}
