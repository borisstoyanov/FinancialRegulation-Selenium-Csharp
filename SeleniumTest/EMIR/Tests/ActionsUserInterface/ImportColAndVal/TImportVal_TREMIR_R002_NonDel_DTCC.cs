using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TImportVal_TREMIR_R002_NonDel_DTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.TREMIR_R010_NonDelegated_DTCC();

        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportValuation"), TestMethod()]
        public void ImportVal_TREMIR_R002_NonDelegated_DTCC()
        {
            storeResults = true;
            ImportValuation.ImportValuation_TREMIR_R002_NonDelegated();
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
