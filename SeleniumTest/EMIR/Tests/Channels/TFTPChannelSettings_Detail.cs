using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TFTPChannelSettings_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void FTPChannelSetting_ViewFTPChannelSettings()
        {
            storeResults = true;
            PO_FTPChannelSettingsPopUp referenceDatas = PO_Dashboard.GoToFTPChannelSettingsPopUp();
            referenceDatas.CreateNewFTPChannelSettings()
                .Create();
            referenceDatas.VerifyFTPChannelSettingsCreated();
            referenceDatas.ViewFTPChannelSettingsDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
