using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TChannelFileMasks_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRChannelFileMask_CreateChannelFileMasks()
        {
            storeResults = true;
            PO_ChannelFileMasksPopUp referenceData = PO_Dashboard.GoToChannelFileMasksPopUp();
            referenceData.CreateNewChannelFileMasks()
                .Create();
            referenceData.VerifyChannelFileMasksCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
