using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TSourceSystems_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void SourceSystem_EditSourceSystems()
        {
            storeResults = true;
            PO_SourceSystemsPopUp referenceDatas = PO_Dashboard.GoToSourceSystemPopUp();
            referenceDatas.CreateNewSourceSystem()
                .Create();
            referenceDatas.VerifySourceSystemCreated();
            referenceDatas.EditSourceSystem()
                .Save();
            referenceDatas.VerifySourceSystemEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
