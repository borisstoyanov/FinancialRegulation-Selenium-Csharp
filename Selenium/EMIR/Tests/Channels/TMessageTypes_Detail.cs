using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TMessageTypes_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MessageType_ViewMessageTypes()
        {
            storeResults = true;
            PO_MessageTypesPopUp referenceDatas = PO_Dashboard.GoToMessageTypesPopUp();
            referenceDatas.CreateNewMessageTypes()
                .Create();
            referenceDatas.VerifyMessageTypesCreated();
            referenceDatas.ViewMessageTypesDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
