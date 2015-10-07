
namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_DashboardConfiguredQueuesTabs
    {
        public PO_DashboardConfiguredQueues ValuationQueues()
        {
            return new PO_DashboardConfiguredQueues("Valuations Queues");
        }

        public PO_DashboardConfiguredQueues EmirQueues()
        {
            return new PO_DashboardConfiguredQueues("EMIR Queues");
        }

        public PO_DashboardConfiguredQueues CollateralQueues()
        {
            return new PO_DashboardConfiguredQueues("Collateral Queues");
        }

        public PO_DashboardConfiguredQueues ApprovalQueues()
        {
            return new PO_DashboardConfiguredQueues("Approvals Queues");
        }
    }
}
