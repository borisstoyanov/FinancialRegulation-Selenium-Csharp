using AutomationUtilities.Utils;
using OpenQA.Selenium;

namespace AutomationUtilities.PageObjects
{
    public class PO_HelpAbout
    {
        public static string Getbuild()
        {
            if (Util.IsElementVisible(By.XPath("//span[text()='Close']")))
            {
                Browser.Browser.ClickByXPath("//span[text()='Close']");
            }
            GoToHelpAbout();
            Util.WaitForElementPresentByXPath("//div[@id='ui-id-10']", 15);
            return Browser.Browser.Instance.FindElement(By.Id("ui-id-10")).Text;
        }

        private static void GoToHelpAbout()
        {
            Util.WaitForElementPresentByXPath("//div[@id='HelpImage']", 15);
            Browser.Browser.ClickByID("HelpImage");
            Util.WaitForElementPresentByXPath("//a[text()='About']", 15);
            Browser.Browser.ClickByXPath("//a[text()='About']");

        }
    }
}
