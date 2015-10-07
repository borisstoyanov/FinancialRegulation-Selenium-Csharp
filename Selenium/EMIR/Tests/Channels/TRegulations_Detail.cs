using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TRegulations_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void Regulation_ViewRegulations()
        {
            storeResults = true;
            PO_RegulationsPopUp referenceDatas = PO_Dashboard.GoToRegulationsPopUp();
            referenceDatas.CreateNewRegulations()
                .Create();
            referenceDatas.VerifyRegulationsCreated();
            referenceDatas.ViewRegulationsDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
