using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ManageWorkQueues
    {
        public PO_ManageWorkQueues()
        {

            try
            {

                Util.WaitForElementPresentByXPath("//*[contains(text(),'Work Queues')]", 15);

            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
                Test.TearDown(true);

            }
        }

        public void CreateLastWeekTradesQueue()
        {
            Browser.Browser.ClickByXPath("//a[text()='Create']");
            Util.WaitForElementPresentByXPath("//h2[text()='Create EMIR Work Queue']", 15);
            Browser.Browser.Instance.FindElement(By.Id("WorkQueue_Name")).SendKeys(Test.extRef = "TestAutomation" );
            Browser.Browser.Instance.FindElement(By.Id("WorkQueue_Description")).SendKeys(Test.extRef);
  //          new SelectElement(Browser.Browser.Instance.FindElement(By.Id("WorkQueue_WorkQueueCategory"))).SelectByText("Transaction In Progress");
            ClickNext();
            Util.WaitForElementPresentByXPath("//input[@id='AddAll']", 15);
            Browser.Browser.ClickByID("AddAll");
            Thread.Sleep(1000);
            ClickNext();
            Util.WaitForElementPresentByXPath("//input[@id='AddAll']", 15);
            Browser.Browser.ClickByID("AddAll");
            Thread.Sleep(1000);
            ClickNext();
            Util.WaitForElementPresentByXPath("//select[@id='UnselectedWorkQueueWhere']", 15);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("UnselectedWorkQueueWhere"))).SelectByText("Created Date");
            Browser.Browser.ClickByID("Add");
            Util.WaitForElementPresentByXPath("//select[@id='SelectedWorkQueueWhereDateType']", 15);
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("SelectedWorkQueueWhereDateType"))).SelectByText("Dynamic");
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("SelectedWorkQueueWhereValueDateDynamicTypeString"))).SelectByText("Last Week");
            Browser.Browser.ClickByID("Ok");
            ClickNext();
            Util.WaitForElementPresentByXPath("//input[@id='AddAll']", 15);
            Browser.Browser.ClickByID("AddAll");
            Thread.Sleep(1000);
            Browser.Browser.ClickByID("Save");
            Util.CheckIfTextPresented("Work Queue has been created");

        }

        public void FindWorkQueue(string extRef)
        {
            Util.CheckIfTextPresented(extRef);
        }

        public void CheckWorkQueueNotVisible(string extRef)
        {
            Util.CheckIfTextNotPresented(extRef);
        }

        private void ClickNext()
        {
            Browser.Browser.ClickByID("Next");
        }

        public void DeleteWorkQueue(string p)
        {
            SearchWorkQueue(Test.extRef);
            Browser.Browser.ClickByXPath("//a[text()='Delete']");

            Util.WaitForElementPresentByXPath("//input[@id='Delete']", 15);
            Browser.Browser.ClickByID("Delete");
            Util.WaitForElementPresentByXPath("//*[text()='EMIR Work Queues']", 15);
        }

        private void SearchWorkQueue(string p)
        {
            Browser.Browser.Instance.FindElement(By.Id("Search_NameSearch")).SendKeys(Test.extRef);
            Browser.Browser.ClickByID("Save");
            Util.WaitForElementPresentByXPath("//td[text()='" + Test.extRef + "']", 15);


        }
    }
}
