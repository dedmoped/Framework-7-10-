using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Framework.model;

namespace Framework.Pages
{
    class TakePlace
    {
        IWebDriver Browser;
        [FindsBy(How = How.ClassName, Using = "theme__default__u5Zsw")]
        private IWebElement People;
        [FindsBy(How = How.ClassName, Using = "Select__listItem__2iqJZ")]
        private IWebElement PeopleNumber;
        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div[5]/div/div[2]/div[1]/div/button/div/span/span[1]")]
        private IWebElement Children;
        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div[5]/div/div[2]/div[1]/div/span/div/div/div/div[2]")]
        private IWebElement ChildrenNumber;
        [FindsBy(How = How.ClassName, Using = "radio__radio__1-Chd")]
        private IWebElement cupe;
        [FindsBy(How = How.ClassName, Using = "inner_wrapper")]
        private IWebElement NextPage;
        [FindsBy(How = How.ClassName, Using = "_pseudo")]
        private IWebElement activ;
        [FindsBy(How = How.ClassName, Using = "alert_title")]
        private IWebElement Error;

        public TakePlace(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser, this);
        }
        public TakePlace ChooseNumberOfPeoples()
        {
            People.Click();
            PeopleNumber.Click();
            return this;
        }
        public TakePlace CheckChildrenNumber()
        {
            People.Click();
            PeopleNumber.Click();
            Children.Click();
            ChildrenNumber.Click();
            return this;
        }
        public DataTest CorrectNumber()
        {
            People.Click();
            cupe.Click();
            NextPage.Click();
            return  new DataTest(Browser);
        }
        public string GetError()
        {
            return Error.Text;
        }
      
    }
}
