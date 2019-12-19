using System;

namespace Framework.model
{
    class Way
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity{ get; set; }
        public string DepartureDate { get; set; }

        public Way(string departureCity, string arrivalCity,string departureDate)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureDate = departureDate;
        }
    }
}
