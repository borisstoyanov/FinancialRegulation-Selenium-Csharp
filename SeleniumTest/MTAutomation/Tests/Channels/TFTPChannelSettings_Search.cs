using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TMTFTPChannelSettings_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithSystemUser();

            PO_FTPChannelSettingsPopUp referenceDatas = PO_Dashboard.GoToFTPChannelSettingsPopUp();
            referenceDatas.CreateNewFTPChannelSettings()
                .Create();
            referenceDatas.VerifyFTPChannelSettingsCreated();

            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTFTPChannelSetting_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_FTPChannelSettingsPopUp referenceDatas = PO_Dashboard.GoToFTPChannelSettingsPopUp();
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
