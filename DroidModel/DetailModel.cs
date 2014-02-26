using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroidModel
{
    public class DetailModel
    {
        public int TotalNoofPassenger { get; set; }
        public int NoofPassengerDeparted { get; set; }
        public int NoofPassengerarrived { get; set; }
        public string FromBuilding { get; set; }
        public string ToBuilding { get; set; }
        public string DateofJourney { get; set; }
    }
}
