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
using System.Threading;

namespace Framework.Pages
{
    class HomePage
    {
        //public static ILog Log = LogManager.GetLogger("LOGGER");

        private IWebDriver Browser;
        [FindsBy(How=How.Name, Using = "schedule_station_from")] 
        private IWebElement Station_from;
        [FindsBy(How = How.Name, Using = "schedule_station_to")]
        private IWebElement Station_to;
        [FindsBy(How = How.ClassName, Using = "j-date_to")]
        private IWebElement Date;
        [FindsBy(How = How.ClassName, Using = "m-border_inner")]
        private IWebElement Find;
        [FindsBy(How = How.ClassName, Using = "date_back_container")]
        private IWebElement BackDate;
        [FindsBy(How = How.ClassName, Using = "j-link-register")]
        private IWebElement Register;
        [FindsBy(How = How.ClassName, Using = "j-agree")]
        private IWebElement ChekBox;
        [FindsBy(How = How.XPath, Using = "//*[@id='reg-container']/div/div[1]/div[1]/form/div[4]/button")]
        private IWebElement RegisterButton;
        [FindsBy(How = How.ClassName, Using = "paragraph")]
        private IWebElement Station_Error2;
        [FindsBy(How = How.ClassName, Using = "j-popup-content")]
        private IWebElement Station_Error;

        public HomePage(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser, this);
        }
        
        public Trains InpuntInformationAndMoveTo(Way way)
        {
            Station_from.SendKeys(way.DepartureCity);
            Station_to.SendKeys(way.ArrivalCity);
            Date.SendKeys(way.Departure_date);
            Date.Click();
            Find.Click();
            return new Trains(Browser);
        }
        public HomePage InpuntInformation(Way way)
        {
            Station_from.SendKeys(way.DepartureCity);
            Station_to.SendKeys(way.ArrivalCity);
            Date.SendKeys(way.Departure_date);
            Date.Click();
            Find.Click();
            return this;
        }

        public HomePage Sign()
        {
                Register.Click();
                ChekBox.Click();
                RegisterButton.Click();
            return this;
        }
        public bool EnableBackDate()
        {
            try
            {
                BackDate.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetError()
        {
            return Station_Error.Text;
            
        }
        public string GetErrorRegister()
        {
            return Station_Error2.Text;

        }
    }
}
