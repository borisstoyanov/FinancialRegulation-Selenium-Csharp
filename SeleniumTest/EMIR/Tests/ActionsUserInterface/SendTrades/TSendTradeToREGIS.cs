using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendTrades
{
    [TestClass]
    public class TSendTradeToREGIS : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

            ImportTrade.TREMIR_R010_NonDelegated_REGIS();
        }

        [TestCategory("SendREGIS"), TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendTrades"), TestCategory("ShortSend"), TestCategory("Nightly"), TestMethod()]
        public void TC14487_SendTrade_REGIS()
        {
            storeResults = true;

            Send.SendTrade(TargetSettings_SendTrades.SendRegisTRNewTrades);

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
