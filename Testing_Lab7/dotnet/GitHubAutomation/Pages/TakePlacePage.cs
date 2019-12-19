using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Framework.model;
using log4net;

namespace Framework.Pages
{
    class TakePlacePage
    {
        public static ILog Log = LogManager.GetLogger("LOGGER");

        IWebDriver Browser;
        [FindsBy(How = How.ClassName, Using = "theme__default__u5Zsw")]
        private IWebElement PeopleCountListButton;
        [FindsBy(How = How.ClassName, Using = "Select__listItem__2iqJZ")]
        private IWebElement PeopleCountButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div[5]/div/div[2]/div[1]/div/button/div/span/span[1]")]
        private IWebElement ChildrenCountListButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div[5]/div/div[2]/div[1]/div/span/div/div/div/div[2]")]
        private IWebElement ChildrenCountButton;
        [FindsBy(How = How.ClassName, Using = "radio__radio__1-Chd")]
        private IWebElement ChooseCupeButton;
        [FindsBy(How = How.ClassName, Using = "inner_wrapper")]
        private IWebElement NextPageButton;
        [FindsBy(How = How.ClassName, Using = "alert_title")]
        private IWebElement Error;

        public TakePlacePage(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser, this);
        }
        public TakePlacePage ChooseNumberOfPeoples()
        {
            PeopleCountListButton.Click();
            PeopleCountButton.Click();
            Log.Info("Choose Number of Peoples");
            return this;
        }
        public TakePlacePage CheckChildrenNumber()
        {
            PeopleCountListButton.Click();
            PeopleCountButton.Click();
            ChildrenCountListButton.Click();
            ChildrenCountButton.Click();
            Log.Info("Check Children Number");
            return this;
        }
        public InputInformationPage ChekCorrectNumberOfPeople()
        {
            PeopleCountListButton.Click();
            ChooseCupeButton.Click();
            NextPageButton.Click();
            Log.Info("Chek Correct Number Of People");
            return  new InputInformationPage(Browser);
        }
        public string GetError()
        {
            return Error.Text;
        }
      
    }
}
