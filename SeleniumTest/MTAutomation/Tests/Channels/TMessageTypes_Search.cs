using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TMTMessageTypes_Search : Test
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

            PO_MessageTypesPopUp referenceDatas = PO_Dashboard.GoToMessageTypesPopUp();
            referenceDatas.CreateNewMessageTypes()
                .Create();
            referenceDatas.VerifyMessageTypesCreated();

            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTMessageType_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_MessageTypesPopUp referenceDatas = PO_Dashboard.GoToMessageTypesPopUp();
            referenceDatas.SearchMessageTypes(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Thread.Sleep(2000);
            Test.TearDown(storeResults);
        }
    }
}
