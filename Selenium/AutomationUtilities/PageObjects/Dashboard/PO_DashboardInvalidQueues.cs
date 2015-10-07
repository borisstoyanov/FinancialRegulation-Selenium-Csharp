
using OpenQA.Selenium;
using System;
namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_DashboardInvalidQueues
    {
        private string secID;

        public PO_DashboardInvalidQueues(string secID)
        {
            this.secID = secID;
        }

        public PO_EMIRQueue RepairRequiredQueue()
        {
            ClickQueue("Repair Required");
            return new PO_EMIRQueue("Repair Required");
        }

        private void ClickQueue(string workQueue)
        {
            Browser.Browser.ClickByXPath("//div[@id='" + secID + "']//div[@title='Click for " + workQueue + " Work Queue List']");
        }

        public int GetRepairRequiredCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Repair Required']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue RejectedQueue()
        {
            ClickQueue("Rejected");
            return new PO_EMIRQueue("Rejected");
        }

        public int GetRejectedCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Rejected']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public PO_EMIRQueue OtherQueue()
        {
            ClickQueue("Other");
            return new PO_EMIRQueue("Other");
        }

        public int GetOtherCount()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Other']//..//div[@class='DashboardProgress_Heading_Total']")).Text.ToString().Replace(",", ""));
            return count;
        }

        public int GetTotal()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[text()='Invalid']//..//div[@class='DashboardSummary_SectionB_Top_Column_OverallTotal']")).Text.ToString().Replace(",", ""));
            return count;
        }
    }
}
