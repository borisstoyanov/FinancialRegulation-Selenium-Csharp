using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TProducts_CreateProduct : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            storeResults = true;
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14454_Product_CreateProduct()
        {
            storeResults = true;
            PO_ProductsPopUp products = PO_Dashboard.GoToProducts();
            products.CreateNewProduct()
               .SetProductInputField(ProductInputFields.EMIRProduct_BloombergCode, "test")
               .Create();
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
