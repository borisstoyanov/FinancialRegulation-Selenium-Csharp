using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TSourceSettings_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestMethod()]
        public void EMIRSourceSetting_CreateSourceSetting()
        {
            storeResults = true;
            PO_SourceSettingsPopUp referenceData = PO_Dashboard.GoToSourceSettingsPopUp();
            referenceData.CreateNewSourceSetting()
                .Create();
            referenceData.VerifySourceSettingsCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
