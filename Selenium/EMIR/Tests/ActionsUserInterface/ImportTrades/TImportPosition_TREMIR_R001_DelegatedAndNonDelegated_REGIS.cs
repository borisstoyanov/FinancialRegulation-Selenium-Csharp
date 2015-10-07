using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TImportPosition_TREMIR_R001_DelegatedAndNonDelegated_REGIS : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportPosition"), TestMethod()]
        public void ImportPosition_TREMIR_R001_Delegated_REGIS()
        {
            storeResults = true;
            ImportPosition.TREMIR_R001_Delegated_REGIS();
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportPosition"), TestMethod()]
        public void ImportPosition_TREMIR_R001_NonDelegated_REGIS()
        {
            storeResults = true;
            ImportPosition.TREMIR_R001_NonDelegated_REGIS();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
