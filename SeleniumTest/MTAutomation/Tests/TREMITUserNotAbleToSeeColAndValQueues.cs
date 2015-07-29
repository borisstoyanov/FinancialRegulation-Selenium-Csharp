using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests
{
    [TestClass]
    public class TREMITUserNotAbleToSeeColAndValQueues : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_REMITUser();
        }

        [TestMethod]
        public void REMITUserNotAbleToSeeColAndValQueues()
        {
            storeResults = true;

            Util.CheckIfTextNotPresented("Valuations Queues");
            Util.CheckIfTextNotPresented("Collateral Queues");


            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
