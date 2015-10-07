using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_EditEmirCollateralPage
    {
        public PO_EditEmirCollateralPage()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='Collateral']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void EditCollateral(String amount)
        {
            Browser.Browser.ClickByXPath("//div[text()='Collateral']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("8_Collateral_CollateralValue_ExternalDiv"));
            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).Clear();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(amount);
            Browser.Browser.ClickByXPath("//button[@class='editable-submit ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only EMIRButtonStyle']");
            Browser.Browser.ClickByID("EditValidateButton");
        }
    }
}
