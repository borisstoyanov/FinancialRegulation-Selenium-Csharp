using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemitAutomation.Tests
{
    [TestClass]
    public class TLogin : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
        }

        [TestCategory("Login"), TestMethod()]
        public void Login()
        {
            storeResults = true;
            Test.LoginAsSystemUser();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
