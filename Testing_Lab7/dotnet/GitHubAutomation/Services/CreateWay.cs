using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.model;
using GitHubAutomation.Services;

namespace Framework.Services
{
    class CreateWay
    {
        public static Way GetTestStationInfo()
        {
            return new Way(StationsReader.GetData("DepartureCity").Value, StationsReader.GetData("ArrivalCity").Value, StationsReader.GetData("Departure_date").Value);
        }

        public static Way CheckDate()
        {
            return new Way(TestPastDate.GetData("DepartureCity").Value, TestPastDate.GetData("ArrivalCity").Value, TestPastDate.GetData("Departure_date").Value);
        }

        public static Way GetPeopleNumberInfo()
        {
            return new Way(TestNumberofPeople.GetData("DepartureCity").Value, TestNumberofPeople.GetData("ArrivalCity").Value, TestNumberofPeople.GetData("Departure_date").Value);
        }
        public  static Way Stations()
        {
            return new Way(StationsReader.GetData("ArrivalCity").Value, StationsReader.GetData("DepartureCity").Value, StationsReader.GetData("Departure_date").Value);
        }
    }
}
