using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ActionsButton.Import;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemitAutomation.Utils;

namespace RemitAutomation.Tests.Actions.ImportOrder
{
    [TestClass]
    public class TFieldValidationInput_Order : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestCategory("RegressionTesting"), TestMethod()]
        public void FieldValidationInput_Order_MissingSTI()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("uniqueOrderIdentifier", "")
                .SaveXML().Import();
            importPage.VerifyTransformError();
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestCategory("RegressionTesting"), TestMethod()]
        public void FieldValidationInput_Order_Unlinked()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("orderType", "NewBorisUnlinked")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestCategory("RegressionTesting"), TestMethod()]
        public void FieldValidationInput_Order_MEV()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("orderCondition", "MEV")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestMethod()]
        public void FieldValidationInput_Order_MEV_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("orderCondition", "MEV")
                .EditTradeNode("minimumExecuteVolume", "value", "")
                .SaveXML().Import();
            importPage.VerifyTransformError();
           
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestCategory("RegressionTesting"), TestMethod()]
        public void FieldValidationInput_Order_Price_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceLimit", "currency", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestCategory("RegressionTesting"), TestMethod()]
        public void FieldValidationInput_Order_PriceLimit_NotCorrect()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceLimit", "John Lennon")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15); 
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestCategory("RegressionTesting"), TestMethod()]
        public void FieldValidationInput_Order_MissingVolumes()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("undisclosedVolume", "unit", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15); 
            Test.result = "Passed";
        }

        //[TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportOrder"), TestMethod()]
        public void FieldValidationInput_Order_ActionCancel()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("actionType", "C")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
