using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAutomation.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_CheckApplicationHistory : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestMethod()]
        public void Dashboard_CheckApplicationHistory()
        {
            storeResults = true;
            ImportTrade.Trade("no");
            PO_Dashboard.GoTo();
            PO_Dashboard dash = new PO_Dashboard();
            dash.CheckHistory();

            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportTrade.TestSecondTenant();

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
            Test.MarkTradeAsUsed();
        }
    }
}
