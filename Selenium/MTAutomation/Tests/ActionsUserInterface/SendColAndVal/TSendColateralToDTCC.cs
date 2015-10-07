using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.SendColAndVal
{
    [TestClass]
    public class TSendColateralToDTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.TREMIR_R010_Delegated_DTCC();
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();

            Send.SendTrade(TargetSettings_SendTrades.SendDTCCETDTradeNewRecords);
            PO_UTISearch.GoTo(Test.UTI, 5);

            emirTransactionPage.VerifySendSuccessfully(100);
            emirTransactionPage.VerifyEMIRConfirmed();
            ImportCollateral.GenXML_Delegated();
        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendCollateral"), TestCategory("Nightly"), TestMethod()]
        public void TC14505_SendCollateral_DTCC()
        {
            storeResults = true;
            Send.SendCollateral(TargetSettings_SendCollateral.dtcc);

            PO_UserAccountButton.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_SendCollaterals sendTradesPage = PO_Dashboard.GoToSendCollateralsByTargetSetting();
            sendTradesPage.SelectTargetSEtting(TargetSettings_SendTrades.SendRegisTRNewTrades);
            Util.CheckIfTextNotPresented(Test.UTI);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
