using System.Threading;

namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_DashboardConfiguredQueues
    {
        private string tab;

        public PO_DashboardConfiguredQueues(string tab)
        {
            this.tab = tab;
            Browser.Browser.ClickByXPath("//a[text()='" + tab + "']");
            Thread.Sleep(500);
        }

        public PO_ManageWorkQueues GoToAddWorkQ()
        {
            return new PO_ManageWorkQueues();
        }

        public PO_EMIRQueue OpenWorkQ(string workQName)
        {
            Browser.Browser.ClickByXPath("//div[@id='DashboardConfiguredQueues']//div[text()='" + workQName + "']");
            return new PO_EMIRQueue(workQName);
        }
    }
}
