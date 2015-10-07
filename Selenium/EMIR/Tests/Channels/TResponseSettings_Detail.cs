using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TResponseSettings_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRResponseSetting_ViewResponseSettings()
        {
            storeResults = true;
            PO_ResponseSettingsPopUp referenceDatas = PO_Dashboard.GoToResponseSettingsPopUp();
            referenceDatas.CreateNewResponseSettings()
                .Create();
            referenceDatas.VerifyResponseSettingsCreated();
            referenceDatas.ViewResponseSettingsDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
