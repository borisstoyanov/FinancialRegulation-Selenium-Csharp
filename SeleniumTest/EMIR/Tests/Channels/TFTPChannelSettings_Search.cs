using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TFTPChannelSettings_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_FTPChannelSettingsPopUp referenceDatas = PO_Dashboard.GoToFTPChannelSettingsPopUp();
            referenceDatas.CreateNewFTPChannelSettings()
                .Create();
            referenceDatas.VerifyFTPChannelSettingsCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void FTPChannelSetting_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_FTPChannelSettingsPopUp referenceDatas = new PO_FTPChannelSettingsPopUp();
            referenceDatas.SearchFTPChannelSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void FTPChannelSetting_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_FTPChannelSettingsPopUp referenceDatas = new PO_FTPChannelSettingsPopUp();
            referenceDatas.SearchFTPChannelSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void FTPChannelSetting_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_FTPChannelSettingsPopUp referenceDatas = new PO_FTPChannelSettingsPopUp();
            referenceDatas.SearchFTPChannelSettings(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void FTPChannelSetting_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_FTPChannelSettingsPopUp referenceDatas = new PO_FTPChannelSettingsPopUp();
            referenceDatas.SearchFTPChannelSettings(searchTerm);
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
