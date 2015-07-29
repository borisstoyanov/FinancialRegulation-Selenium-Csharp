
using OpenQA.Selenium;
using System;
namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_DashboardInProgressQueues
    {
        private string secID;

        public PO_DashboardInProgressQueues(string secID)
        {
            this.secID = secID;
        }

        public PO_EMIRQueue ConfirmationRequiredQueue()
        {
            ClickQueue("Confirmation Required");
            return new PO_EMIRQueue("Confirmation Required");
        }

        private void ClickQueue(string workQueue)
        {
            Browser.Browser.ClickByXPath("//div[@id='" + secID + "']//div[@class='DashboardSummary_SectionB_Body_Column2']//div[contains(@title,'Click for " + workQueue + "')]");
        }

        public int GetConfirmationRequiredCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Confirmation Required']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue ClearingRequiredQueue()
        {
            ClickQueue("Clearing Required");
            return new PO_EMIRQueue("Clearing Required");
        }

        public int GetClearingRequiredCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Clearing Required']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue AwaitingAutoRevalidationQueue()
        {
            ClickQueue("Trades Awaiting Auto re-Validation");
            return new PO_EMIRQueue("Trades Awaiting Auto re-Validation");
        }

        public int GetAwaitingAutoRevalidationCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Trades Awaiting Auto re-Validation']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue AwaitingQueue()
        {
            ClickQueue("Awaiting");
            return new PO_EMIRQueue("Awaiting");
        }

        public int GetAwaitingCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[@class='DashboardSummary_SectionB_Body_Column2']//div[contains(text(),'Awaiting')]//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue UnmachedQueue()
        {
            ClickQueue("Unmatched");
            return new PO_EMIRQueue("Unmatched");
        }

        public int GetUnmatchedCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[@class='DashboardSummary_SectionB_Body_Column2']//div[contains(text(),'Unmatched')]//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }


        public int GetTotal()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='In Progress']//..//div[@class='DashboardSummary_SectionB_Top_Column_OverallTotal']")).Text.ToString().Replace(",", ""));
            return count;
        }
    }
}
