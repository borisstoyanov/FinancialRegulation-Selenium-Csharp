using AutomationUtilities.Utils;
using OpenQA.Selenium;
using System.Threading;
using AutomationUtilities.PageObjects.ActionsButton;
using AutomationUtilities.PageObjects.Audit;

namespace AutomationUtilities.PageObjects
{
    public class PO_ActionButton
    {
        public static void Engage()
        {
            Browser.Browser.ClickByID("ActionsImage");
        }

        private static void ClickBySourceSetting()
        {
            Util.WaitForElementVisibleByXPath("//a[text()='By Source Setting']", 15);
            Browser.Browser.ClickByXPath("//a[text()='By Source Setting']");
        }

        private static void ClickTrades()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Trades']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Trades']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Trades']");
            }
        }


        private static void ClickCollateral()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='ActionsImageDashboardHeadingMenu']//a[text()='Collaterals']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ActionsImageDashboardHeadingMenu']//a[text()='Collaterals']");
            Util.WaitForElementVisibleByXPath("//a[text()='Collaterals']//..//a[text()='By Source Setting']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Collaterals']//..//a[text()='By Source Setting']");
        }

        private static void ClickImport()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Import']")))            
            {
                Util.WaitForElementPresentByXPath("//a[text()='Import']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Import']");
            }
        }

        public static void GoToImportTradeBySource()
        {
            Engage();
            ClickImport();
            ClickTrades();
            ClickBySourceSetting();
        }

        public static void GoToImportCollateralBySource()
        {
            Engage();
            ClickImport();
            ClickCollateral();
        }

        public static void GoToImportValuationBySource()
        {
            Engage();
            ClickImport();
            ClickValuation();
        }

        private static void ClickValuation()
        {
            Util.WaitForElementPresentByXPath("//ul[@id='ActionsImageDashboardHeadingMenu']//a[text()='Valuations']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ActionsImageDashboardHeadingMenu']//a[text()='Valuations']");
            Util.WaitForElementPresentByXPath("//a[text()='Valuations']//..//a[text()='By Source Setting']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Valuations']//..//a[text()='By Source Setting']");
        }

        public static void GoToSendTradesByTargetSetting()
        {
            Engage();
            ClickSend();
            ClickSendTradesByTargetSetting();
        }

        private static void ClickSendTradesByTargetSetting()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Trades']")))
            {
                Util.WaitForElementVisibleByXPath("//a[text()='Send']//..//a[text()='Trades']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Trades']");
            }
            Util.WaitForElementVisibleByXPath("//a[text()='Send']//..//a[text()='Trades']//..//a[text()='By Target Setting']", 15);
            Thread.Sleep(300);
            Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Trades']//..//a[text()='By Target Setting']");
        }

        private static void ClickSend()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Send']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Send']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Send']");
            }
        }

        public static void GoToSendCollateralsByTargetSetting()
        {
            Engage();
            ClickSend();
            ClickSendCollateralsByTargetSetting();
        }

        private static void ClickSendCollateralsByTargetSetting()
        {
            Util.WaitForElementPresentByXPath("//a[text()='Send']//..//a[text()='Collaterals']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Collaterals']");
            Util.WaitForElementPresentByXPath("//a[text()='Send']//..//a[text()='Collaterals']//..//a[text()='By Target Setting']", 15);
            Thread.Sleep(300);
            Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Collaterals']//..//a[text()='By Target Setting']");
        }

        public static void GoToSendValuationsByTargetSetting()
        {
            Engage();
            ClickSend();
            ClickSendValuationsByTargetSetting();
        }

        private static void ClickSendValuationsByTargetSetting()
        {
            Util.WaitForElementPresentByXPath("//a[text()='Send']//..//a[text()='Valuations']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Valuations']");
            Util.WaitForElementPresentByXPath("//a[text()='Send']//..//a[text()='Valuations']//..//a[text()='By Target Setting']", 15);
            Thread.Sleep(300);
            Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Valuations']//..//a[text()='By Target Setting']");
        }

        public static void GoToManageWorkQueuesTrades()
        {
            Engage();
            ClickManage();
            ClickWorkQueuesTrades();
        }

        private static void ClickWorkQueuesTrades()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Work Queues']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Manage']//..//a[text()='Work Queues']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Manage']//..//a[text()='Work Queues']");
            }
            
            Util.WaitForElementPresentByXPath("//a[text()='Manage']//..//a[text()='Work Queues']//..//a[text()='Trades']", 15);
            Thread.Sleep(300);
            Browser.Browser.ClickByXPath("//a[text()='Manage']//..//a[text()='Work Queues']//..//a[text()='Trades']");
        }

        private static void ClickManage()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Manage']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Manage']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Manage']");
            }
        }

        internal static void GoToImportProduct()
        {
            Engage();
            ClickImport();
            ClickProducts();
        }

        private static void ClickProducts()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Products']")))
            {
                Util.WaitForElementVisibleByXPath("//a[text()='Import']//..//a[text()='Products']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Import']//..//a[text()='Products']");
            }
            Util.WaitForElementVisibleByXPath("//a[text()='Products']//..//a[text()='By Source Setting']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Products']//..//a[text()='By Source Setting']");
        }

        internal static void GoToSendTradesByTradeRepo()
        {
            Engage();
            ClickSend();
            ClickSendTradesByTradeRepo();
        }

        private static void ClickSendTradesByTradeRepo()
        {
            if (!Util.IsElementVisible(By.XPath("//a[@class='dcjq-parent active'][text()='Trades']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Send']//..//a[text()='Trades']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Trades']");
            }
            Util.WaitForElementPresentByXPath("//a[text()='Send']//..//a[text()='Trades']//..//a[text()='By Trade Repository Account']", 15);
            Thread.Sleep(300);
            Browser.Browser.ClickByXPath("//a[text()='Send']//..//a[text()='Trades']//..//a[text()='By Trade Repository Account']");
        }

        internal static void GoToManageRefIns()
        {
            Engage();
            ClickManage();
            ClickExtRefIn();
        }

        private static void ClickExtRefIn()
        {
            Util.WaitForElementVisibleByXPath("//a[text()='Ext Ref Ins']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Ext Ref Ins']");
        }

        private static void ClickSources()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Sources']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Sources']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Sources']");
            }
        }

        private static void ClickInbound()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/SourcesInbound')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/SourcesInbound')]");
        }

        private static void ClickOutbound()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/SourcesOutbound')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/SourcesOutbound')]");
        }

        private static void ClickResponse()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/SourcesResponse')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/SourcesResponse')]");
        }

        private static void ClickAuditResponse()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesResponse')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesResponse')]");
        }

        private static void ClickAuditApprovals()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesApprovals')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesApprovals')]");
        }

        private static void ClickAuditCollaterals()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesCollateral')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesCollateral')]");
        }

        private static void ClickAuditInbound()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesInbound')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesInbound')]");
        }

        private static void ClickAuditOutbound()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesOutbound')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesOutbound')]");
        }

        private static PO_AuditTradePopUp ClickAuditTrade()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesTrade')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesTrade')]");
            return new PO_AuditTradePopUp();
        }

        private static void ClickAuditValuation()
        {
            Util.WaitForElementVisibleByXPath("//a[contains(@href,'/Information/AuditEntriesValuation')]", 15);
            Browser.Browser.ClickByXPath("//a[contains(@href,'/Information/AuditEntriesValuation')]");
        }

        internal static void GoToInboundSources()
        {
            Engage();
            ClickSources();
            ClickInbound();
        }

        internal static void GoToOutboundSources()
        {
            Engage();
            ClickSources();
            ClickOutbound();
        }

        internal static void GoToResponseSources()
        {
            Engage();
            ClickSources();
            ClickResponse();
        }

        internal static void GoToAuditResponses()
        {
            Engage();
            ClickAudit();
            ClickAuditResponse();
        }

        internal static void GoToAuditApprovals()
        {
            Engage();
            ClickAudit();
            ClickAuditApprovals();
        }

        internal static void GoToAuditCollaterals()
        {
            Engage();
            ClickAudit();
            ClickAuditCollaterals();
        }

        internal static void GoToAuditInbound()
        {
            Engage();
            ClickAudit();
            ClickAuditInbound();
        }

        internal static void GoToAuditOutbound()
        {
            Engage();
            ClickAudit();
            ClickAuditOutbound();
        }

        internal static void GoToAuditTrade()
        {
            Engage();
            ClickAudit();
            ClickAuditTrade();
        }
        internal static void GoToAuditValuation()
        {
            Engage();
            ClickAudit();
            ClickAuditValuation();
        }


        private static void ClickAudit()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Audit']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Audit']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Audit']");
            }
        }

        internal static void GoToExternalRefInsPromote()
        {
            Engage();
            ClickManage();
            ClickPromoteExtRefIns();
        }

        private static void ClickPromoteExtRefIns()
        {
            Util.WaitForElementVisibleByXPath("//a[text()='Promote Ext Ref Ins']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Promote Ext Ref Ins']");
        }



        internal static void GoToImportOrdersBySource()
        {
            Engage();
            ClickImport();
            ClickOrders();
            ClickBySourceSettingOrders();
        }

        private static void ClickOrders()
        {
            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Orders']")))
            {
                Util.WaitForElementPresentByXPath("//a[text()='Orders']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Orders']");
            }
        }

        private static void ClickBySourceSettingOrders()
        {
            Util.WaitForElementVisibleByXPath("//a[text()='Orders']//..//a[text()='By Source Setting']", 15);
            Browser.Browser.ClickByXPath("//a[text()='Orders']//..//a[text()='By Source Setting']");
        }
    }
}
