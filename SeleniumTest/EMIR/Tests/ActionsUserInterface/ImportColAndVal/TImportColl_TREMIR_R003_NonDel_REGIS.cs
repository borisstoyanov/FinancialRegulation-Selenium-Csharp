using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TImportColl_TREMIR_R003_NonDel_REGIS : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("No");

        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportCollateral"), TestMethod()]
        public void ImportColl_TREMIR_R003_NonDelegated_REGIS()
        {
            storeResults = true;
            ImportCollateral.GenXML_NonDelegated();
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
