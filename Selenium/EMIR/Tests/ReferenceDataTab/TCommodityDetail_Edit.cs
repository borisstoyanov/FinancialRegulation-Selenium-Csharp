using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TCommodityDetails_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRCommodityDetail_EditCommodityDetails()
        {
            storeResults = true;
            PO_CommodityDetail_PopUp referenceDatas = PO_Dashboard.GoToCommodityDetailsPopUp();
            referenceDatas.CreateNewComDetails()
                .Create();
            referenceDatas.VerifyComDetailCreated();
            referenceDatas.EditReferenceData()
                .SetField(CommodityDetailFieldIDs.Name, "TA" + Util.GetRandomID())
                .Save();
            referenceDatas.VerifyReferenceDataEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
