using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TImportColl_GenericXML_ByPortfolioCode : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("Yes");

        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportCollateral"), TestMethod()]
        public void ImportColl_GenXML_ByPortfolioCode()
        {
            storeResults = true;
            ImportCollateral.GenXML_ByPortfolioCode();
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
