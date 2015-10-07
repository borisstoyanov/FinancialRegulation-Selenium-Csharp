using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTargetSettings_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRTargetSetting_ViewTargetSettings()
        {
            storeResults = true;
            PO_TargetSettingsPopUp referenceDatas = PO_Dashboard.GoToTargetSettingsPopUp();
            referenceDatas.CreateNewTargetSetting()
                .Create();
            referenceDatas.VerifyTargetSettingsCreated();
            referenceDatas.ViewTargetSettingsDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
