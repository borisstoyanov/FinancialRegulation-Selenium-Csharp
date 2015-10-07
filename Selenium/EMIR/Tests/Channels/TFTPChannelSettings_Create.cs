using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TFTPChannelSettings_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void FTPChannelSetting_CreateFTPChannelSettings()
        {
            storeResults = true;
            PO_FTPChannelSettingsPopUp referenceData = PO_Dashboard.GoToFTPChannelSettingsPopUp();
            referenceData.CreateNewFTPChannelSettings()
                .Create();
            referenceData.VerifyFTPChannelSettingsCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
