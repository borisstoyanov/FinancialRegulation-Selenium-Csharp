
using OpenQA.Selenium;
using System;
namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_DashboardValidQueues
    {
        private string secID;

        public PO_DashboardValidQueues(string secID)
        {
            this.secID = secID;
        }

        public PO_EMIRQueue ReadyQueue()
        {
            ClickQueue("Ready");
            return new PO_EMIRQueue("Ready");
        }

        private void ClickQueue(string workQueue)
        {
            Browser.Browser.ClickByXPath("//div[@id='" + secID + "']//div[contains(@title,'" + workQueue + "')]");
        }

        public int GetReadyCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[contains(text(),'Ready')]//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue ReportedQueue()
        {
            ClickQueue("Reported");
            return new PO_EMIRQueue("Reported");
        }

        public int GetReported()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Reported']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue ConfirmedQueue()
        {
            ClickQueue("Confirmed");
            return new PO_EMIRQueue("Confirmed");
        }

        public int GetConfirmed()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[contains(text(),'Confirmed')]//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue AwaitingParentConfirmationQueue()
        {
            ClickQueue("Awaiting Parent Confirmation");
            return new PO_EMIRQueue("Awaiting Parent Confirmation");
        }

        public int GetAwaitingParentConfirmationCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Awaiting Parent Confirmation']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public int GetTotal()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Valid']//..//div[@class='DashboardSummary_SectionB_Top_Column_OverallTotal']")).Text.ToString().Replace(",", ""));
            return count;
        }
    }
}
