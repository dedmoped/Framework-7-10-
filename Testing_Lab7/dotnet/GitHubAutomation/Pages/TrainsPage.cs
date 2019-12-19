using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using log4net;
using GitHubAutomation.Services;

namespace Framework.Pages
{
    class TrainsPage
    {

        [FindsBy(How = How.ClassName, Using = "_blue")]
        private IWebElement ChooseFirstTrain;
        [FindsBy(How = How.ClassName, Using = "b-alert__standart")]
        private IWebElement Error;
        private IWebDriver Browser;

        public TrainsPage(IWebDriver Browser)
        {
            this.Browser = Browser;
            PageFactory.InitElements(Browser,this);
        }
        public TakePlacePage TakeFirstTrain()
        {
            ChooseFirstTrain.Click();
            ChangeWindow(Browser);
            Logger.Log.Info("Take First Train");
            return new TakePlacePage(Browser);
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
            Logger.Log.Info("Get Error");
            return Error.Text;
        }

    }
}
