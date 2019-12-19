using NUnit.Framework;
using Framework.Pages;
using Framework.Services;
using Framework.Tests;
using GitHubAutomation.Services;

namespace Framework
{
    class TransportTest : TestConfig
    {

        [Test]
        public void TestArrivedStation()
        {
            Logger.InitLogger();
            HomePage homePage = new HomePage(Browser)
                .InpuntInformation(CreateWay.GetTestStationInfo());
            Assert.AreEqual("Пожалуйста, укажите название станции", homePage.GetError());
        }
        [Test]
        public void TestNumberOfPeople()
        {
            TakePlacePage takePlace = new HomePage(Browser)
                .InpuntInformationAndMoveToNextPage(CreateWay.GetPeopleNumberInfo())
                .TakeFirstTrain().ChooseNumberOfPeoples();
            Assert.AreEqual("Вы не выбрали ни одного пассажира", takePlace.GetError());
        }

        [Test]
        public void StationFromTest()
        {
            HomePage homePage = new HomePage(Browser)
                .InpuntInformation(CreateWay.Stations());
            Assert.AreEqual("Пожалуйста, укажите название станции", homePage.GetError());
        }

        [Test]
        public void TestBackDate()
        {
            TrainsPage trainsPage = new HomePage(Browser)
                .InpuntInformationAndMoveToNextPage(CreateWay.CheckDate());
            Assert.AreEqual("Вы выбрали прошедшую дату 12 декабря. Попробуйте поискать билеты на другой день\r\n.", trainsPage.GetError());
        }

        [Test]
        public void TestChildrenBuyTickets()
        {
            TakePlacePage takePlacePage = new HomePage(Browser)
                .InpuntInformationAndMoveToNextPage(CreateWay.GetPeopleNumberInfo())
                .TakeFirstTrain()
                .CheckChildrenNumber();
            Assert.AreEqual("Ребенок до 10 лет не может ехать без взрослого", takePlacePage.GetError());
        }

        [Test]
        public void TestPeopleInformation()
        {
            InputInformationPage inputInformationPage = new HomePage(Browser)
                .InpuntInformationAndMoveToNextPage(CreateWay.GetPeopleNumberInfo())
                .TakeFirstTrain().ChekCorrectNumberOfPeople()
                .ClickFindButton();
            Assert.AreEqual("Это поле необходимо заполнить", inputInformationPage.GetPersonalInformationError());
        }

        [Test]
        public void TestEmptyCompanyField()
        {
            InputInformationPage inputInformationPage = new HomePage(Browser)
                .InpuntInformationAndMoveToNextPage(CreateWay.GetPeopleNumberInfo())
                .TakeFirstTrain().ChekCorrectNumberOfPeople()
                .CheckCompany();
            Assert.AreEqual("Это поле необходимо заполнить", inputInformationPage.GetPersonalInformationError());
        }


        [Test]
        public void TestDocumentNumber()
        {
            InputInformationPage inputInformationPage = new HomePage(Browser)
                .InpuntInformationAndMoveToNextPage(CreateWay.GetPeopleNumberInfo())
                .TakeFirstTrain().ChekCorrectNumberOfPeople().CheckPersonalInformation();
            Assert.AreEqual("Вы ошиблись при вводе номера документа.", inputInformationPage.GetEnterCompanyError());
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
            HomePage homePage = new HomePage(Browser)
                .EnterRegistrationButton();
            Assert.AreEqual("Укажите электронную почту", homePage.GetErrorRegister());
        }
    }
}
