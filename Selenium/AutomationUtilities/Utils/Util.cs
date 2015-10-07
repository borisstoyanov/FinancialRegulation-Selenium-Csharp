using AutomationUtilities.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;

namespace AutomationUtilities.Utils
{
    public class Util
    {
        public static string GetUniqueFileName(String fileExtension)
        {
            var myUniqueFileName = string.Format(@"{0}." + fileExtension, Guid.NewGuid());
            return myUniqueFileName;
        }

        
        public static string GetRandomID ()
        {
            Random r = new Random();
            return r.Next(10000,99999).ToString();
        }

        public static bool IsElementPresent(By by)
        {
            try
            {
                Browser.Browser.Instance.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public static void  CheckIfTextPresented(string textToFind)
        {
            try
            {
                Thread.Sleep(2000);
                Assert.IsTrue(Browser.Browser.Instance.PageSource.Contains(textToFind));
            }
            catch (AssertFailedException e)
            {
                Test.verificationErrors.Append(e.Message);
                Assert.Fail("The text: '"+textToFind+"' was not found");
            }
        }

        public static void WaitForElementPresentByXPath(string xpath, int timeOut)
        {
            new WebDriverWait(Browser.Browser.Instance, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((By.XPath(xpath))));
        }
        public static void WaitForElementVisibleByXPath(string xpath, int timeOut)
        {
            new WebDriverWait(Browser.Browser.Instance, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementIsVisible((By.XPath(xpath))));
        }

        public static void RemoveDisplay(string id)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.Browser.Instance;
            js.ExecuteScript("document.getElementById('" + id + "').removeAttribute('style');");
        }

        public static bool CheckIfPassedAndAbort()
        {
            List<TestResults> selectPassed = SQLServerUtilities.SelectPassedTestsByTestInstance(Test.testInstance);
            if(selectPassed.Count>0)
            {
                TestResults firstResult = selectPassed.First();
                if (firstResult.build.Equals(Test.build) &&
                firstResult.browserVersion.Equals(Test.browserVersion) &&
                firstResult.testInstance.Equals(Test.instanceURL))
                {
                    return true;
                }
                    else
                    {
                         return false;
                    }
            }else
            {
                return false;
            }
        }

        

        public static void CheckIfOneOfTextsPresented(string thisText, string orThisText)
        {
            try
            {
                Assert.IsTrue(Browser.Browser.Instance.PageSource.Contains(thisText) || Browser.Browser.Instance.PageSource.Contains(orThisText));
            }
            catch (AssertFailedException e)
            {
                Test.verificationErrors.Append(e.Message);
                Assert.Fail("The text: '" + thisText + "  or " + orThisText +" ' was not found");
            }
        }

        public static string GetTestID()
        {
            return DateTime.Now.ToString("ddHHmmssf");
        }

        public static void SaveScreenshot(Screenshot screenshot)
        {
            screenshot.SaveAsFile(ConfigurationManager.AppSettings["remoteLocation"] + Test.testName + Test.testID + ".jpg", ImageFormat.Jpeg);
        }

        internal static bool IsElementVisible(By by)
        {
            try
            {
                new WebDriverWait(Browser.Browser.Instance, TimeSpan.FromSeconds(1)).Until(ExpectedConditions.ElementIsVisible((by)));
                return true;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public static void CheckIfTextNotPresented(string textToFind)
        {

            if(IsElementPresent(By.XPath("//*[text()='" + textToFind + "']")))
            {
                Test.verificationErrors.Append("The text: '" + textToFind + "' was found!");
                Assert.Fail("The text: '" + textToFind + "' was found!");
            }
        }

        internal static void WaitForElementNotVisibleByXPath(string textToFind, int timeOut)
        {
            for (int i = 0; i <= timeOut; i++)
            {
                if (Util.IsElementPresent(By.XPath(textToFind)))
                {
                    if (i == timeOut)
                    {
                        Test.verificationErrors.Append("Timeout: Trade was not found/imported.");
                        Assert.Fail("Timeout: Trade was not found/imported.");
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }
        }

        internal static void CheckIfOneOfElementsPresented(string thisText, string orThisText)
        {

            try
            {
                Assert.IsTrue(Browser.Browser.Instance.FindElement(By.XPath(thisText)).Displayed || Browser.Browser.Instance.FindElement(By.XPath(orThisText)).Displayed);
            }
            catch (AssertFailedException e)
            {
                Test.verificationErrors.Append(e.Message);
                Assert.Fail("The text: '" + thisText + "  or " + orThisText + " ' was not found");
            }
        }

        internal static bool IsOneOfElementsPresented(string thisText, string orThisText)
        {

            if (Util.IsElementVisible(By.XPath(thisText)) || Util.IsElementVisible(By.XPath(orThisText)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static void CheckIfOneOfElementsPresented(string thisText, string orThisText, int timeout)
        {

            for (int i = 0; i <= timeout; i++)
            {
                if (Util.IsElementVisible(By.XPath(thisText)) || Util.IsElementVisible(By.XPath(orThisText)))
                {
                    break; 
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Timeout: Trade was not found/imported.");
                        Assert.Fail("Timeout: Trade was not found/imported.");
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        internal static void ExecuteJavascript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.Browser.Instance;
            js.ExecuteScript(script);
        }
    }
}