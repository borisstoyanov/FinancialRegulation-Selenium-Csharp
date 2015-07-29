using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TResponseSettings_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_ResponseSettingsPopUp referenceDatas = PO_Dashboard.GoToResponseSettingsPopUp();
            referenceDatas.CreateNewResponseSettings()
                .Create();
            referenceDatas.VerifyResponseSettingsCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRResponseSetting_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ResponseSettingsPopUp referenceDatas = new PO_ResponseSettingsPopUp();
            referenceDatas.SearchResponseSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRResponseSetting_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ResponseSettingsPopUp referenceDatas = new PO_ResponseSettingsPopUp();
            referenceDatas.SearchResponseSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRResponseSetting_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_ResponseSettingsPopUp referenceDatas = new PO_ResponseSettingsPopUp();
            referenceDatas.SearchResponseSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRResponseSetting_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ResponseSettingsPopUp referenceDatas = new PO_ResponseSettingsPopUp();
            referenceDatas.SearchResponseSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
