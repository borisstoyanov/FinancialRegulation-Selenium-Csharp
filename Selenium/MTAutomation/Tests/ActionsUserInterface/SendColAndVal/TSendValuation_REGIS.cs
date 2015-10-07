using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.SendColAndVal
{
    [TestClass]
    public class TSendValuation_REGIS : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.TREMIR_R010_NonDelegated_REGIS();
            Send.SendTrade(TargetSettings_SendTrades.SendRegisTRNewTrades);
            EmirUtils.VerifyEmirConfirmed();
            ImportValuation.ImportValuation_TREMIR_R002_NonDelegated();
        }

        [TestCategory("Send"), TestCategory("Nightly"), TestCategory("ActionsUI"), TestCategory("SendValuation"), TestMethod()]
        public void TC14499_SendValuation_REGIS()
        {
            storeResults = true;
            Send.SendValuation(TargetSettings_SendValuation.REGIS);

            PO_UserAccountButton.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_SendCollaterals sendTradesPage = PO_Dashboard.GoToSendCollateralsByTargetSetting();
            sendTradesPage.SelectTargetSEtting(TargetSettings_SendValuation.REGIS);
            Util.CheckIfTextNotPresented(Test.UTI);
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
