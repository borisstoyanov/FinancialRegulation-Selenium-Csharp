using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_CommodityDetail_Edit
    {
        public PO_CommodityDetail_Edit SetField(string field, string value)
        {
            Browser.Browser.Instance.FindElement(By.Id(field)).Clear();
            Browser.Browser.Instance.FindElement(By.Id(field)).SendKeys(value);
            return this;    
        }

        public PO_CommodityDetail_Edit SelectField(String fieldID, String value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id(fieldID))).SelectByText(value);
            return this;
        }

        public void Save()
        {
            Browser.Browser.ClickByID("Save");
            Thread.Sleep(2000);
        }
    }
}
