using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TChannelFileMasks_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_ChannelFileMasksPopUp referenceDatas = PO_Dashboard.GoToChannelFileMasksPopUp();
            referenceDatas.CreateNewChannelFileMasks()
                .Create();
            referenceDatas.VerifyChannelFileMasksCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRChannelFileMask_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ChannelFileMasksPopUp referenceDatas = new PO_ChannelFileMasksPopUp();
            referenceDatas.SearchChannelFileMasks(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRChannelFileMask_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ChannelFileMasksPopUp referenceDatas = new PO_ChannelFileMasksPopUp();
            referenceDatas.SearchChannelFileMasks(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRChannelFileMask_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_ChannelFileMasksPopUp referenceDatas = new PO_ChannelFileMasksPopUp();
            referenceDatas.SearchChannelFileMasks(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRChannelFileMask_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ChannelFileMasksPopUp referenceDatas = new PO_ChannelFileMasksPopUp();
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
