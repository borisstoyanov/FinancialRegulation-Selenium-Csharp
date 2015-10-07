using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TProducts_EditProduct : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14455_Product_EditProduct_EditBloombergCode()
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
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithRegularUser();
            PO_Dashboard.GoToProducts();
            products.EditProduct()
                .SetProductInputField(ProductInputFields.EMIRProduct_BloombergCode, Util.GetRandomID())
                .Save();
            products.VerifyProductIsCreated();
            Test.result = "Passed";

        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
