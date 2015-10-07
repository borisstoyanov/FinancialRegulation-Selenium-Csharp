using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemitAutomation.Tests.Products.ProductContractSeries
{
    [TestClass]
    public class TCreateProdContractSeries_CreateProductSer : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITSysUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("CreateProductSer"), TestCategory("RegressionTesting"), TestMethod()]
        public void CreateProductSer_Create()
        {
            storeResults = true;
            PO_ProductContractSeriesPopUp products = PO_Dashboard.GoToProductContractSer();
            products.CreateNewProduct()
               .Create();
            products.VerifyProductSeriesIsCreated();
            Test.result = "Passed";
        }


        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("CreateProductSer"), TestCategory("RegressionTesting"), TestMethod()]
        public void CreateProductSer_Edit()
        {
            storeResults = true;
            PO_ProductContractSeriesPopUp products = PO_Dashboard.GoToProductContractSer();
            products.CreateNewProduct()
               .Create();
            products.VerifyProductSeriesIsCreated();
            products.EditProductSeries()
                .SetProductInputField("ProductContractSeries_StrikePrice", "3")
                .Save();
            products.VerifyProductSeriesIsEditted();
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("CreateProductSer"), TestCategory("RegressionTesting"), TestMethod()]
        public void CreateProductSer_View()
        {
            storeResults = true;
            PO_ProductContractSeriesPopUp products = PO_Dashboard.GoToProductContractSer();
            products.CreateNewProduct()
               .Create();
            products.VerifyProductSeriesIsCreated();
            products.ViewDetails();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
