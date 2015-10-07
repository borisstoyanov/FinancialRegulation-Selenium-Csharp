using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_UTISearch
    {
        public static PO_EditEmirTransactionPage GoTo(string searchTerm, int timeout)
        {
            Util.RemoveDisplay("utiSearch");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(searchTerm);
            for (int i = 0; i <= timeout; i++)
            {
                if (Util.IsElementPresent(By.XPath("//title[contains(text(),'Transaction')]")))
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
                    Util.WaitForElementVisibleByXPath("//input[@class='utiSearch']", 15);
                    Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(Keys.Return);
                    Thread.Sleep(5000);
                }
            }
            return new PO_EditEmirTransactionPage();
        }

        public static bool GoToSecondTenantTest(string searchTerm)
        {
            Util.RemoveDisplay("utiSearch");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(searchTerm);

                if (Util.IsElementPresent(By.XPath("//title[contains(text(),'Transaction')]")))
                {
                    Assert.Fail("Timeout: Trade was not found/imported.");
                    return false;
                }
                return true;
        }

        public static PO_SearchResult SearchFor(string searchTerm)
        {
            ClickSearchFor(searchTerm);
            return new PO_SearchResult();
        }

        public static void ClickSearchFor(string searchTerm)
        {
            Util.RemoveDisplay("utiSearch");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(searchTerm);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(Keys.Return);
        }
    }
}
