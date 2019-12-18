using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    class Trains
    {
        [FindsBy(How = How.ClassName, Using = "_blue")]
        private IWebElement First_Train;
        [FindsBy(How = How.ClassName, Using = "b-alert__standart")]
        private IWebElement Error;
        private IWebDriver Browser;

        public Trains(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser,this);
        }
        public TakePlace Takefirst()
        {
            First_Train.Click();
            ChangeWindow(Browser);
            return new TakePlace(Browser);
        }

        private void ChangeWindow(IWebDriver Browser)
        {
            List<string> arrayList = new List<string>(Browser.WindowHandles);
            Browser.SwitchTo().Window(arrayList[0]);
            Browser.Close();
            Browser.SwitchTo().Window(arrayList[1]);
        }
        public string GetError()
        {
            return Error.Text;
        }

    }
}
