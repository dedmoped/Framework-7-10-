using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.model
{
    class Way
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity{ get; set; }
        public string Departure_date { get; set; }

        public Way(string departureCity, string arrivalCity,string departure_date)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Departure_date = departure_date;
        }
    }
}
