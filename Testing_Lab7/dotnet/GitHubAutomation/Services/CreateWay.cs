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
            return new Way(PastDateReader.GetData("DepartureCity").Value, PastDateReader.GetData("ArrivalCity").Value, PastDateReader.GetData("Departure_date").Value);
        }

        public static Way GetPeopleNumberInfo()
        {
            return new Way(PeopleReader.GetData("DepartureCity").Value, PeopleReader.GetData("ArrivalCity").Value, PeopleReader.GetData("Departure_date").Value);
        }
        public  static Way Stations()
        {
            return new Way(StationsReader.GetData("ArrivalCity").Value, StationsReader.GetData("DepartureCity").Value, StationsReader.GetData("Departure_date").Value);
        }
    }
}
