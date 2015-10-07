using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.SendColAndVal
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

            PO_UserAccountButton.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_SendCollaterals sendTradesPage = PO_Dashboard.GoToSendCollateralsByTargetSetting();
            sendTradesPage.SelectTargetSEtting(TargetSettings_SendCollateral.regis);
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
