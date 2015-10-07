using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendTrades
{
    [TestClass]
    public class TSendTradesToDTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

            ImportTrade.TREMIR_R010_NonDelegated_DTCC();

        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendTrades"), TestCategory("ShortSend"), TestCategory("SendDTCC"), TestCategory("Nightly"), TestMethod()]
        public void TC14489_SendTrade_DTCC()
        {
            storeResults = true;

            Send.SendTrade(TargetSettings_SendTrades.SendDTCCETDTradeNewRecords);

            EmirUtils.VerifyEmirConfirmed();


            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
