using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TProducts_Decline4eyes : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("Nightly"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14461_Product_Reject4Eyes()
        {
            storeResults = true;
            PO_ProductsPopUp products = PO_Dashboard.GoToProducts();
            products.CreateNewProduct()
                .Create();
            products.VerifyProductIsCreated();
            products.CloseWindow();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.DeclineStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithRegularUser();
            PO_Dashboard.GoToProducts(); 
            products.VerifyCounterPartyIsNotFound();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
