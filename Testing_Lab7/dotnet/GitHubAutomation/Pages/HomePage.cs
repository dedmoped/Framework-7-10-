using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Framework.model;
using log4net;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    class HomePage
    {
        WebDriverWait wait;
        public static ILog Log = LogManager.GetLogger("LOGGER");

        private IWebDriver Browser;
        [FindsBy(How=How.Name, Using = "schedule_station_from")] 
        private IWebElement StationFromField;
        [FindsBy(How = How.Name, Using = "schedule_station_to")]
        private IWebElement StationToField;
        [FindsBy(How = How.ClassName, Using = "j-date_to")]
        private IWebElement DateField;
        [FindsBy(How = How.ClassName, Using = "m-border_inner")]
        private IWebElement FindButton;
        [FindsBy(How = How.ClassName, Using = "date_back_container")]
        private IWebElement BackDateButton;
        [FindsBy(How = How.ClassName, Using = "j-link-register")]
        private IWebElement BeginRegistrationButton;
        [FindsBy(How = How.ClassName, Using = "j-agree")]
        private IWebElement ActiveRegistrationCheckBox;
        [FindsBy(How = How.XPath, Using = "//*[@id='reg-container']/div/div[1]/div[1]/form/div[4]/button")]
        private IWebElement RegistrationButton;
        [FindsBy(How = How.ClassName, Using = "paragraph")]
        private IWebElement RegistrationError;
        [FindsBy(How = How.ClassName, Using = "j-popup-content")]
        private IWebElement StationError;

        public HomePage(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser, this);
        }
        
        public TrainsPage InpuntInformationAndMoveToNextPage(Way way)
        {
            CleareField(StationFromField, StationToField, DateField);
            StationFromField.SendKeys(way.DepartureCity);
            StationToField.SendKeys(way.ArrivalCity);
            DateField.SendKeys(way.DepartureDate);
            DateField.Click();
            FindButton.Click();
            Log.Info("Input Station Information and move to next page");
            return new TrainsPage(Browser);
        }
        public HomePage InpuntInformation(Way way)
        {
            CleareField(StationFromField, StationToField, DateField);
            StationFromField.SendKeys(way.DepartureCity);
            StationToField.SendKeys(way.ArrivalCity);
            DateField.SendKeys(way.DepartureDate);
            DateField.Click();
            FindButton.Click();
            Log.Info("Input Station Information");
            return this;
        }

        public HomePage EnterRegistrationButton()
        {
            BeginRegistrationButton.Click();
            ActiveRegistrationCheckBox.Click();
            RegistrationButton.Click();
            Log.Info("Enter registration button");
            return this;
        }
        public bool EnableBackDate()
        {
            try
            {
                BackDateButton.Click();
                Log.Info("Click backdate button");
                return true;
            }
            catch
            {
                Log.Info("Backdate button notclicked");
                return false;
            }
        }

        public string GetError()
        {
            Log.Info("Get station error");
            return StationError.Text;            
        }

        public string GetErrorRegister()
        {
            Log.Info("Get registration error");
            return RegistrationError.Text;
        }
        public void CleareField(IWebElement stationfrom,IWebElement stationto,IWebElement date )
        {
            wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(StationFromField)).Click();
            StationFromField.Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(StationToField)).Click();
            StationToField.Clear();
        }
    }
}
