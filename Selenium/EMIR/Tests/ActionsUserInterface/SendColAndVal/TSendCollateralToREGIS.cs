using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendColAndVal
{
    [TestClass]
    public class TSendCollateralToREGIS : Test
    {
        bool storeResults;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

            ImportTrade.TREMIR_R010_Delegated_REGIS();

            Send.SendTrade(TargetSettings_SendTrades.SendRegisTRNewTrades);

            EmirUtils.VerifyEmirConfirmed();
        }

        [TestCategory("Send"), TestCategory("Nightly"), TestCategory("ActionsUI"), TestCategory("SendCollateral"), TestMethod()]
        public void TC14501_SendCollateral_REGIS()
        {
            storeResults = true;

            ImportCollateral.GenXML_Delegated();


            Send.SendCollateral(TargetSettings_SendCollateral.regis);

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
