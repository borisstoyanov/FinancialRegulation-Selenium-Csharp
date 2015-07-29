using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TMessageTypes_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_MessageTypesPopUp referenceDatas = PO_Dashboard.GoToMessageTypesPopUp();
            referenceDatas.CreateNewMessageTypes()
                .Create();
            referenceDatas.VerifyMessageTypesCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MessageType_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_MessageTypesPopUp referenceDatas = new PO_MessageTypesPopUp();
            referenceDatas.SearchMessageTypes(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MessageType_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_MessageTypesPopUp referenceDatas = new PO_MessageTypesPopUp();
            referenceDatas.SearchMessageTypes(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MessageType_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_MessageTypesPopUp referenceDatas = new PO_MessageTypesPopUp();
            referenceDatas.SearchMessageTypes(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MessageType_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_MessageTypesPopUp referenceDatas = new PO_MessageTypesPopUp();
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
