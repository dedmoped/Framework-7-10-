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
            return new Way(StationsReader.GetData("DepartureCity"), StationsReader.GetData("ArrivalCity"), StationsReader.GetData("Departure_date"));
        }

        public static Way CheckDate()
        {
            return new Way(TestPastDate.GetData("DepartureCity"), TestPastDate.GetData("ArrivalCity"), TestPastDate.GetData("Departure_date"));
        }

        public static Way GetPeopleNumberInfo()
        {
            return new Way(TestNumberofPeople.GetData("DepartureCity"), TestNumberofPeople.GetData("ArrivalCity"), TestNumberofPeople.GetData("Departure_date"));
        }
        public  static Way Stations()
        {
            return new Way(StationsReader.GetData("ArrivalCity"), StationsReader.GetData("DepartureCity"), StationsReader.GetData("Departure_date"));
        }
    }
}
