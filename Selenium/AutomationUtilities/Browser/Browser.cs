// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Browser.cs" company="Impendium">
//   ==============================================================================================
//   //  Impendium
//   //  Copyright (c) 2015, Impendium Corporation. All Rights Reserved.
//   //  Warning: This computer program is protected by copyright law and international treaties.
//   //  Unauthorised reproduction or distribution of this program, or any portion of it, may result
//   //  in severe civil and criminal penalties, and will be prosecuted to the maximum extent
//   //  possible under law.
//   // ==============================================================================================
// </copyright>
// <summary>
//   The browser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AutomationUtilities.Browser
{
    using System;
    using System.Configuration;
    using System.Diagnostics;

using AutomationUtilities.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

    /// <summary>
    /// The browser.
    /// </summary>
    public class Browser
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static Lazy<IWebDriver> instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static IWebDriver Instance
{
            get
    {
                if (instance == null || !instance.IsValueCreated)
                {
                    GetNewInstance();
                }

                return instance.Value;
            }
        }

        /// <summary>
        /// The init.
        /// </summary>
        internal static void Init()
        {
            Quit();
            GetNewInstance();
        }

        /// <summary>
        /// The quit.
        /// </summary>
        public static void Quit()
        {
            if (instance!=null && instance.IsValueCreated)
            {
                instance.Value.Quit();
                instance.Value.Dispose();
        }

            instance = null;
        }

        /// <summary>
        /// The get new instance.
        /// </summary>
        private static void GetNewInstance()
        {
            string browserConfig = ConfigurationManager.AppSettings["browser"];
            string hubHost = ConfigurationManager.AppSettings["hubHost"];
            string browserVersion = ConfigurationManager.AppSettings["browserVersion"];

            if (browserConfig.Equals("FF") && browserVersion.Equals("34"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                capabilities.SetCapability(CapabilityType.Version, "34");
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));
            }

            if (browserConfig.Equals("FF") && browserVersion.Equals("35"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                capabilities.SetCapability(CapabilityType.Version, "35");
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));
            }

            if (browserConfig.Equals("CH") && browserVersion.Equals("39"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                capabilities.SetCapability(CapabilityType.Version, "39");
                Environment.SetEnvironmentVariable(
                    "webdriver.chrome.driver", 
                    @ConfigurationManager.AppSettings["driverLocation"] + "chromedriver.exe");
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));
            }

            if (browserConfig.Equals("CH") && browserVersion.Equals("38"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                capabilities.SetCapability(CapabilityType.Version, "38");
                Environment.SetEnvironmentVariable(
                    "webdriver.chrome.driver", 
                    @ConfigurationManager.AppSettings["driverLocation"] + "chromedriver.exe");
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));
            }

            if (browserConfig.Equals("IE") && browserVersion.Equals("10"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                capabilities.SetCapability(CapabilityType.Version, "10");
                Environment.SetEnvironmentVariable(
                    "webdriver.ie.driver", 
                    @ConfigurationManager.AppSettings["driverLocation"] + "IEDriverServer.exe");
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));

                instance.Value.Navigate().GoToUrl("https://" + Test.instanceURL + "/Home/EMIRWorkQueueSummary");
                instance.Value.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
            }

            if (browserConfig.Equals("IE") && browserVersion.Equals("11"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                Environment.SetEnvironmentVariable(
                    "webdriver.ie.driver", 
                    @ConfigurationManager.AppSettings["driverLocation"] + "IEDriverServer.exe");
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));

                instance.Value.Navigate().GoToUrl("https://" + Test.instanceURL + "/Home/EMIRWorkQueueSummary");
                
                Util.ExecuteJavascript("javascript:document.getElementById('overridelink').click();");
            }

            if (browserConfig.Equals("SF"))
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Safari();
                instance =
                    new Lazy<IWebDriver>(
                        () => new RemoteWebDriver(new Uri("http://" + hubHost + ":4444/wd/hub"), capabilities));
                try
                {
                    instance.Value.Navigate().GoToUrl("https://" + Test.instanceURL + "/Home/EMIRWorkQueueSummary");
                }
                catch (AssertFailedException)
                {
                    Process.Start(@ConfigurationManager.AppSettings["remoteLocation"] + "script.exe");
                }
            }
        }

        /// <summary>
        /// The get browser version.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetBrowserVersion()
        {
            ICapabilities browserCapabilities = ((RemoteWebDriver)Instance).Capabilities;
            return browserCapabilities.Version;
        }

        /// <summary>
        /// The go to login page.
        /// </summary>
        public static void GoToLoginPage()
        {
            Instance.Navigate().GoToUrl("https://" + Test.instanceURL + "/Home/EMIRWorkQueueSummary");
        }

        public static void GoToPage(string page)
        {
            Instance.Navigate().GoToUrl("https://" + Test.instanceURL + page);
        }

        public static void ClickClose()
        {
            ClickByXPath("(//span[text()='Close'])[2]");
        }

        /// <summary>
        /// The click.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        private static void Click(By by)
        {
            Instance.FindElement(by).Click();
        }

        /// <summary>
        /// The click by x path.
        /// </summary>
        /// <param name="xpath">
        /// The xpath.
        /// </param>
        public static void ClickByXPath(string xpath)
        {
            Click(By.XPath(xpath));
        }

        /// <summary>
        /// The click by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public static void ClickByID(string id)
        {
            Click(By.Id(id));
        }
    }
}
