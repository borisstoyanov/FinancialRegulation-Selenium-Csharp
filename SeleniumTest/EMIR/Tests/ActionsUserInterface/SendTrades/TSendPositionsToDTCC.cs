using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendTrades
{
    [TestClass]
    public class TSendPositionsToDTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportPosition.TREMIR_R001_NonDelegated_DTCC();

        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendPosition"), TestCategory("ShortSend"), TestCategory("Nightly"), TestCategory("SendDTCC"), TestMethod()]
        public void TC14490_SendPosition_DTCC()
        {
            storeResults = true;

            Send.SendTrade(TargetSettings_SendTrades.SendDTCCETDPositionNewRecords);

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
