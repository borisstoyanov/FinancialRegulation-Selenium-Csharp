
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_DashboardStatuses
    {
        private string secID;

        public PO_DashboardStatuses(string sectionID)
        {
            this.secID = sectionID;
        }

        public PO_DashboardValidQueues Valid()
        {
            return new PO_DashboardValidQueues(secID);
        }

        public PO_DashboardInProgressQueues InProgress()
        {
            return new PO_DashboardInProgressQueues(secID);
        }

        public PO_DashboardInvalidQueues Invalid()
        {
            return new PO_DashboardInvalidQueues(secID);
        }

        public int GetTotal()
        {
            int count = Convert.ToInt32(Browser.Browser.Instance.FindElement(By.XPath("//div[@id='" + secID + "']//div[@class='DashboardChart_Dougnut_CentralMessage_Amount']//span")).Text.ToString().Replace(",", ""));
            return count;
        }

        public void CollapseSection()
        {
            Browser.Browser.ClickByXPath("//div[@id='" + secID + "']//div[@class='DashboardSummaryCollapse']");
            VerifyCollapsed();
        }

        private void VerifyCollapsed()
        {
            Thread.Sleep(1000);
            if (Util.IsElementVisible(By.XPath("//div[@id='" + secID + "']//div[@class='DashboardChart_Dougnut_CentralMessage_Amount']//span")))
            {
                Assert.Fail("Did not collapsed");
            }
        }

        public void ExpandSection()
        {
            Thread.Sleep(1000);
            Browser.Browser.ClickByXPath("//div[@id='" + secID + "_DashboardSummaryCollapsedBar']");
            VerifyExpanded();
        }

        private void VerifyExpanded()
        {
            Thread.Sleep(1000);
            if (!Util.IsElementVisible(By.XPath("//div[@id='" + secID + "']//div[@class='DashboardChart_Dougnut_CentralMessage_Amount']//span")))
            {
                Assert.Fail("Did not expanded");
            }
        }
    }
}
