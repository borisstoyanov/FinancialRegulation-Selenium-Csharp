using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TSourceSettings_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestMethod()]
        public void EMIRSourceSetting_EditSourceSettings()
        {
            storeResults = true;
            PO_SourceSettingsPopUp referenceDatas = PO_Dashboard.GoToSourceSettingsPopUp();
            referenceDatas.CreateNewSourceSetting()
                .Create();
            referenceDatas.VerifySourceSettingsCreated();
            referenceDatas.EditSourceSettings()
                .Save();
            referenceDatas.VerifySourceSettingsEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
