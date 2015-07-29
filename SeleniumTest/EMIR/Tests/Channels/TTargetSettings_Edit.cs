using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTargetSettings_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRTargetSetting_EditTargetSettings()
        {
            storeResults = true;
            PO_TargetSettingsPopUp referenceDatas = PO_Dashboard.GoToTargetSettingsPopUp();
            referenceDatas.CreateNewTargetSetting()
                .Create();
            referenceDatas.VerifyTargetSettingsCreated();
            referenceDatas.EditTargetSettings()
                .Save();
            referenceDatas.VerifyTargetSettingsEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
