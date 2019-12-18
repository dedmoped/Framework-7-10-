using Framework.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class DataTest
    {
        private IWebDriver Browser;
        [FindsBy(How = How.ClassName, Using = "inner_wrapper")]
        private IWebElement Find;
        [FindsBy(How = How.ClassName, Using = "b2b__selectWrapper__2O12k")]
        private IWebElement Change;
        [FindsBy(How = How.ClassName, Using = "m-input_small")]
        private IWebElement ClickDocNumber;
        [FindsBy(How = How.ClassName, Using = "_last_name")]
        private IWebElement Station_Error;
        [FindsBy(How = How.ClassName, Using = "b-popup__content__standart")]
        private IWebElement DocumentError;

        public DataTest(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser, this);
        }

        public DataTest InpuntInformation()
        {
            Find.Click();
            return this;
        }
        public DataTest CheckCompany()
        {
            Change.Click();
            Find.Click();
            return this;
        }
        public DataTest CheckDoc()
        {
            Find.Click();
            ClickDocNumber.Click();
            return this;
        }
        
        public string GetError()
        {
            return Station_Error.Text;
        }
        public string GetDocumentError()
        {
            return DocumentError.Text;
        }

    }
}
