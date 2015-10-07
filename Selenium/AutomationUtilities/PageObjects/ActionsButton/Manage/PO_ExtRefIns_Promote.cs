using AutomationUtilities.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationUtilities.PageObjects.ActionsButton.Manage
{
    public class PO_ExtRefIns_Promote
    {
        public void PromoteExtRefIn(string tenant, string extRefIn_type, string extRefIn_name)
        {
            SearchForExtRefIn(tenant, extRefIn_type, extRefIn_name);
            Promote();
        }

        private void Promote()
        {
            Browser.Browser.ClickByXPath("//input[@value='Promote']");
            Util.WaitForElementVisibleByXPath("//input[@id='Approve']", 15);
            Browser.Browser.ClickByXPath("//input[@id='Approve']");

        }

        private void SearchForExtRefIn(string tenant, string extRefIn_type, string extRefIn)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("Search_EMIRExtRefTypeSearch"))).SelectByText(extRefIn_type);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("Search_TenantID"))).SelectByText(tenant);

            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(extRefIn);
            Browser.Browser.ClickByID("Promote");
            Thread.Sleep(2000);
        }
    }
}
