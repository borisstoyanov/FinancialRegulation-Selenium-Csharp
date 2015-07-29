using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TRegulations_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void Regulation_EditRegulations()
        {
            storeResults = true;
            PO_RegulationsPopUp referenceDatas = PO_Dashboard.GoToRegulationsPopUp();
            referenceDatas.CreateNewRegulations()
                .Create();
            referenceDatas.VerifyRegulationsCreated();
            referenceDatas.EditRegulations()
                .Save();
            referenceDatas.VerifyRegulationsEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
