using Framework.model;
using GitHubAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class InputInformationPage
    {
        private IWebDriver Browser;
        [FindsBy(How = How.ClassName, Using = "inner_wrapper")]
        private IWebElement FindButton;
        [FindsBy(How = How.ClassName, Using = "b2b__selectWrapper__2O12k")]
        private IWebElement ChangeButton;
        [FindsBy(How = How.ClassName, Using = "m-input_small")]
        private IWebElement ClickEnterPersonalInformation;
        [FindsBy(How = How.ClassName, Using = "_last_name")]
        private IWebElement PersonalInformationFieldError;
        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div/div[5]/div/div/div[2]/div/div/div[2]/div[2]/div/div[2]/div[1]/div[2]/div/span/div/div/div")]
        private IWebElement PersonalInformationError;

        public InputInformationPage(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser, this);
        }

        public InputInformationPage ClickFindButton()
        {
            FindButton.Click();
            Logger.Log.Info("Click Find Button");
            return this;
        }
        public InputInformationPage CheckCompany()
        {
            ChangeButton.Click();
            FindButton.Click();
            Logger.Log.Info("Check Company");
            return this;
        }
        public InputInformationPage CheckPersonalInformation()
        {
            FindButton.Click();
            ClickEnterPersonalInformation.Click();
            Logger.Log.Info("Check Personal Information");
            return this;
        }
        
        public string GetPersonalInformationError()
        {
            Logger.Log.Info("Get Personal Information Error");
            return PersonalInformationFieldError.Text;
        }
        public string GetEnterCompanyError()
        {
            Logger.Log.Info("GetEnterCompanyError");
            return PersonalInformationError.Text;
        }

    }
}
