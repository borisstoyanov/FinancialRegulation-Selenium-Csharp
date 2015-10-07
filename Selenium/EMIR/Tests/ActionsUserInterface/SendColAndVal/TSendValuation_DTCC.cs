using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendColAndVal
{
    [TestClass]
    public class TSendValuation_DTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.TREMIR_R010_NonDelegated_DTCC();

            Send.SendTrade(TargetSettings_SendTrades.SendDTCCETDTradeNewRecords);

            EmirUtils.VerifyEmirConfirmed();

            ImportValuation.ImportValuation_TREMIR_R002_NonDelegated();
        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendValuation"), TestCategory("Nightly"), TestMethod()]
        public void TC14502_SendValuation_DTCC()
        {
            storeResults = true;

            Send.SendValuation(TargetSettings_SendValuation.DTCC_Etd);


            result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
            Test.MarkTradeAsUsed();
        }
    }
}
