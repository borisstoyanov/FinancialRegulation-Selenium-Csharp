using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ActionsButton.Import;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemitAutomation.Utils;

namespace RemitAutomation.Tests.Actions.ImportOrder.FieldInputValidation
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

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Order_ContractID()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractId", "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890+")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);

            CreateImportFile.GenXMLOrder();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractId", "!@#$%^&*()")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Order_TransactionTimestamp()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("transactionTime", "John Lennon")
                .SaveXML().Import();
            importPage.VerifyTransformError();
           
            Test.result = "Passed";
        }

        //[TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Order_DeliveryZone()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("deliveryPointOrZone", "123456789012345621231231231231312523454535673243523453457456745634563452345234345636567456746858thfhdye65y56yvegdg5d5tgv45t4+")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);

            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("deliveryPointOrZone", "!@#$%^&*()")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        //[TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Order_PriceLimit()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceLimit", "value", "John Lennon")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);

            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceLimit", "value", "132456789012345678901")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            emirTransactionPage.VerifyStaticIssue(15);

            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceLimit", "value", "12345.123456")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            emirTransactionPage.VerifyStaticIssue(15);

            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Order_TraderIdForOrganisedMarket()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("traderIdForOrganisedMarket", "123456789012345621231231231231312523454535673243523453457456745634563452345234345636567456746858thfhdye65y56yvegdg5d5tgv45t4+")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);

            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("traderIdForOrganisedMarket", "!@#$%^&*()")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            emirTransactionPage.VerifyStaticIssue(15);

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
