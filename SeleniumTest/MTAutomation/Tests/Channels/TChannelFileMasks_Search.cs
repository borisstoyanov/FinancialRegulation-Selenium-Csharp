using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TMTChannelFileMasks_Search : Test
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

            PO_ChannelFileMasksPopUp referenceDatas = PO_Dashboard.GoToChannelFileMasksPopUp();
            referenceDatas.CreateNewChannelFileMasks()
                .Create();
            referenceDatas.VerifyChannelFileMasksCreated();

            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTEMIRChannelFileMask_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ChannelFileMasksPopUp referenceDatas = PO_Dashboard.GoToChannelFileMasksPopUp();
            referenceDatas.SearchChannelFileMasks(searchTerm);
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
