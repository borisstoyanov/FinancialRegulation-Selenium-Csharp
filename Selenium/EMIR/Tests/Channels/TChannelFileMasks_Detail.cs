using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TChannelFileMasks_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRChannelFileMask_ViewChannelFileMasks()
        {
            storeResults = true;
            PO_ChannelFileMasksPopUp referenceDatas = PO_Dashboard.GoToChannelFileMasksPopUp();
            referenceDatas.CreateNewChannelFileMasks()
                .Create();
            referenceDatas.VerifyChannelFileMasksCreated();
            referenceDatas.ViewChannelFileMasksDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
