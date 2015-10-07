using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_SendCollaterals
    {
        public PO_SendCollaterals()
        {
            Thread.Sleep(1000);
            String expectedPage = "Send Collaterals";
            String actualPage = Browser.Browser.Instance.Title.ToString();
            try
            {
                if (!expectedPage.Equals(actualPage))
                {
                    throw new NotOnTheExpectedPageException(expectedPage, actualPage);
                }
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one. \nExpected this: " + e.getExpectedPage() + "\nbut got this: " + e.getActualPage());
                Test.TearDown(true);
            }
        }

        public void SelectTargetSEtting(string targetSetting)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("EMIRTargetSetting"))).SelectByText(targetSetting);
        }

        public void Send()
        {
            Browser.Browser.ClickByID("Submit");
        }

        public void VerifySendingByTargetSetting(string targetSetting)
        {
            Thread.Sleep(500);
            Util.CheckIfTextPresented("EMIR Awaiting Send for selected Target " + targetSetting);
        }

        public void CheckIfAnyAvailableForSending(int timeout, string target)
        {
            for (int i = 0; i <= timeout; i++)
            {
                if (Util.IsElementPresent(By.XPath("//td[text()='EMIR Ready To Send']")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Timeout: There is nothing to send.");
                        Test.TearDown(true);
                        Assert.Fail("Timeout: There is nothing to send.");
                    }
                    PO_Dashboard.GoToSendCollateralsByTargetSetting();
                    Thread.Sleep(5000);
                    new SelectElement(Browser.Browser.Instance.FindElement(By.Id("EMIRTargetSetting"))).SelectByText(target);
                }
            }
        }
    }
}
