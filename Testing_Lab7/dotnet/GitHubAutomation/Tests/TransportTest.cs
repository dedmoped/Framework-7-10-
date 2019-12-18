using NUnit.Framework;
using Framework.Pages;
using Framework.Services;
using Framework.Tests;
using log4net;
using System.Threading;
using GitHubAutomation.Services;

namespace Framework
{
    class TransportTest: TestConfig
    {
        private static ILog Log = LogManager.GetLogger("LOGGER");

        [Test]
        public void TestStation()
        {
            Logger.InitLogger();
            HomePage homePage = new HomePage(Browser).InpuntInformation(CreateWay.GetTestStationInfo());
            Assert.AreEqual("Пожалуйста, укажите название станции",homePage.GetError());
            Logger.Log.Debug("Test complete successfully");
        }
        [Test]
        public void TestNumberOfPeople()
        {
            TakePlace homePage = new HomePage(Browser).InpuntInformationAndMoveTo(CreateWay.GetPeopleNumberInfo()).Takefirst().ChooseNumberOfPeoples(); 
            Assert.AreEqual("Вы не выбрали ни одного пассажира", homePage.GetError());
        }
        //вод одинаковых городов для отправления и прибытия
        [Test]
        public void IdenticalStations()
        {
            HomePage homePage = new HomePage(Browser).InpuntInformation(CreateWay.Stations());
            Assert.AreEqual("Пожалуйста, укажите название станции", homePage.GetError());
        }

        [Test]
        public void CheckDate()
        {
            Trains homePage = new HomePage(Browser).InpuntInformationAndMoveTo(CreateWay.CheckDate());
            Assert.AreEqual("Вы выбрали прошедшую дату 12 декабря. Попробуйте поискать билеты на другой день\r\n.", homePage.GetError());
        }

        [Test]
        public void ChildrenBuyTickets()
        {
            TakePlace homePage = new HomePage(Browser).InpuntInformationAndMoveTo(CreateWay.GetPeopleNumberInfo()).Takefirst().CheckChildrenNumber();
            Assert.AreEqual("Ребенка не посадят в поезд без сопровождающего взрослого. Вы можете оформить детский билет отдельно от билета для сопровождающего", homePage.GetError());
        }

        [Test]
        public void Information()
        {
            DataTest homePage = new HomePage(Browser).InpuntInformationAndMoveTo(CreateWay.GetPeopleNumberInfo()).Takefirst().CorrectNumber().InpuntInformation();
            Assert.AreEqual("Это поле необходимо заполнить", homePage.GetError());
        }

        [Test]
        public void Company()
        { 
            DataTest homePage = new HomePage(Browser).InpuntInformationAndMoveTo(CreateWay.GetPeopleNumberInfo()).Takefirst().CorrectNumber().CheckCompany();
            Assert.AreEqual("Это поле необходимо заполнить", homePage.GetError());
        }


        [Test]
        public void DocumentTest()
        {
            DataTest homePage = new HomePage(Browser).InpuntInformationAndMoveTo(CreateWay.GetPeopleNumberInfo()).Takefirst().CorrectNumber().CheckDoc();
            Assert.AreEqual("Вы ошиблись при вводе номера документа.", homePage.GetDocumentError());
        }

        [Test]
        public void TestEnableDateBack()
        {
            HomePage homePage = new HomePage(Browser);
            Assert.IsTrue(homePage.EnableBackDate());
        }

        [Test]
        public void Register()
        {
            HomePage homePage = new HomePage(Browser);
            Assert.IsTrue(homePage.Sign());
        }
    }
}
