using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTargetSettings_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_TargetSettingsPopUp referenceDatas = PO_Dashboard.GoToTargetSettingsPopUp();
            referenceDatas.CreateNewTargetSetting()
                .Create();
            referenceDatas.VerifyTargetSettingsCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRTargetSetting_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_TargetSettingsPopUp referenceDatas = new PO_TargetSettingsPopUp();
            referenceDatas.SearchTargetSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRTargetSetting_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_TargetSettingsPopUp referenceDatas = new PO_TargetSettingsPopUp();
            referenceDatas.SearchTargetSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRTargetSetting_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_TargetSettingsPopUp referenceDatas = new PO_TargetSettingsPopUp();
            referenceDatas.SearchTargetSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRTargetSetting_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_TargetSettingsPopUp referenceDatas = new PO_TargetSettingsPopUp();
            referenceDatas.SearchTargetSettings(searchTerm);
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
