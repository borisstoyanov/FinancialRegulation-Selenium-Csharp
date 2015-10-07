using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemitAutomation.Tests.Products.CreateProduct
{
    [TestClass]
    public class TCreateProduct_MissingMandatoryFields : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITSysUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("CreateProduct"), TestCategory("RegressionTesting"), TestMethod()]
        public void CreateProduct_MissingMandatoryFields()
        {
            storeResults = true;
            PO_ProductContractSeriesPopUp products = PO_Dashboard.GoToProductContractSer();
            products.CreateNewProduct()
               .CleanField("ProductContractSeries_ContractId")
               .Create();
            products.VerifyMandatoryFieldsValidationError();
            
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("CreateProduct"), TestCategory("RegressionTesting"), TestMethod()]
        public void CreateProduct_IncorrectMandatoryFields()
        {
            storeResults = true;
            PO_ProductContractSeriesPopUp products = PO_Dashboard.GoToProductContractSer();
            products.CreateNewProduct()
               .SetProductInputField("ProductContractSeries_ContractId", "@#$")
               .Create();
            products.VerifyIncorrectFieldInput();

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
