using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_Addresses_CreateAddressPopUp
    {
        public PO_Addresses_CreateAddressPopUp()
        {

            try
            {

                Util.WaitForElementPresentByXPath("//span[@class='ui-dialog-title'][text()='Create']", 60);

            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
            Util.WaitForElementVisibleByXPath("//input[@id='" + AddressesFieldIDs.Address_Name + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(AddressesFieldIDs.Address_Name)).SendKeys(Test.extRef = "TA" + Util.GetRandomID());
            Util.WaitForElementVisibleByXPath("//input[@id='" + AddressesFieldIDs.Address_Line1 + "']", 15);
            Browser.Browser.Instance.FindElement(By.Id(AddressesFieldIDs.Address_Line1)).SendKeys(Test.extRef);
            Browser.Browser.Instance.FindElement(By.Id(AddressesFieldIDs.Address_PostalCode)).SendKeys(Util.GetRandomID());
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(AddressesFieldIDs.Address_Country))).SelectByText("United Kingdom (State Street)");
        }
        public PO_Addresses_CreateAddressPopUp SetAddressInputField(String field, String value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;
        }

        public PO_Addresses_CreateAddressPopUp SetCountry(String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(AddressesFieldIDs.Address_Country))).SelectByText(value);
            return this;
        }
        public void Create()
        {
            Browser.Browser.ClickByXPath("//input[@id='Save']");
            Thread.Sleep(2000);
        }
    }
}
