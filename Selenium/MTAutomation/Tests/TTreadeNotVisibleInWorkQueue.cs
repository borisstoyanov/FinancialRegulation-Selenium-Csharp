using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAutomation.Tests
{
    [TestClass]
    public class TTreadeNotVisibleInWorkQueue : Test
    {
        bool storeResults = false;
        string searchTerm;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            searchTerm = MTUtils.ImportTrade("No");
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestMethod]
        public void TreadeNotVisibleInWorkQueue()
        {
            storeResults = true;
            PO_EMIRQueue wq = PO_Dashboard.GoToEMIRConfiguredQueue("EMIR All Trades");
            wq.VerifyTradeNotVisibleInTheQueue(tradeID + "UTI");
            
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
