using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.Driver;
using NUnit.Framework.Interfaces;
using System.Threading;
using GitHubAutomation.Services;

namespace Framework.Tests
{
    class TestConfig
    {
       
        protected IWebDriver Browser { get; set; }

        [SetUp]
        public void Setter()
        {
            Browser = DriverSingleton.GetDriver();
            Logger.InitLogger();
            Logger.Log.Debug("Browser init");
            Browser.Navigate().GoToUrl("https://www.tutu.ru/");
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Browser.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }

            DriverSingleton.CloseDriver();
        }
    }
}
