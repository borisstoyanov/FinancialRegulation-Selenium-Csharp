using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ActionsButton.Import;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemitAutomation.Utils;

namespace RemitAutomation.Tests.Actions.ImportOrder.CrossFieldValidation
{
    [TestClass]
    public class TOrderCrossFieldValidationTests : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITUser();
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_1_Order_Options()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractType", "OP")
                .EditTradeNode("orderReport", "optionStyle", "")
                .EditTradeNode("contract", "optionStyle", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_2_Order_ExerciseDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contract", "ExerciseDate", "2014-09-01")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_3_Order_DeliveryZone_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("orderReport", "deliveryPointOrZone", "")
                .EditTradeNode("contract", "deliveryPointOrZone", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_4_Order_DeliveryZone_Unbounded()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("orderReport", "deliveryPointOrZone", "AutomationUnboundedZone")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_5b_Order_AuctionBuyOrSell()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractType", "AU")
                .EditTradeNode("buySellIndicator", "B")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_5b_Order_Auction_BuyAndSell()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractType", "AU")
                .EditTradeNode("buySellIndicator", "C")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_5c_Order_Auction_BuyOrSell()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractType", "Option")
                .EditTradeNode("buySellIndicator", "B")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_5c_Order_Auction_BuyAndSell()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contractType", "Option")
                .EditTradeNode("buySellIndicator", "C")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_6_Order_TransactionTime()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "2015-06-30T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_6_Order_TransactionTime_AfterLastTradingDateTime()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("transactionTime", "2015-07-31T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_7_Order_TransactionTime_AfterDeliveryStartDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "")
                .EditTradeNode("OrderReport", "transactionTime", "2015-07-31T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_8_Order_TransactionTime_AfterDeliveryStartDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "")
                .EditTradeNode("OrderReport", "transactionTime", "2015-07-31T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_10_Order_DeliveryStart_AfterDeliveryEndDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("deliveryStartDate", "2015-07-31")
                .EditTradeNode("deliveryEndDate", "2014-07-30")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_11_Order_DeliveryStart_AfterDeliveryEndTime()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "")
                .EditTradeNode("deliveryStartDate", "2015-07-31T12:01:00+02:00")
                .EditTradeNode("deliveryEndDate",    "2015-07-31T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_12_Order_PriceIntervals_Overlap()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("daysOfTheWeek", "TU")
                .EditTradeNode("intervalStartTime", "14:00:00")
                .EditTradeNode("intervalEndTime", "15:00:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_13_Order_SettlementMethod_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contract", "settlementMethod", "")
                .EditTradeNode("OrderReport", "settlementMethod", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_14_Order_OptionType_Unlinked()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("optionType", "AutomationUnlinkedItem")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_14_Order_OptionStyle_Unlinked()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("optionStyle", "AutomationUnlinkedItem")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_15_Order_VolumeQuantity_Unit()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("OrderReport", "value", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_15_Order_VolumeQuantity_Unit_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("OrderReport", "value", "")
                .EditTradeNode("OrderReport", "unit", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_16_Order_PriceDetails_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("OrderReport", "price", "")
                .EditTradeNode("OrderReport", "priceCurrency", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_16_Order_PriceDetails_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("OrderReport", "price", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_17_Order_QuantityIntervalSection_VolumeQuantity_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "")
                .EditTradeNode("priceIntervalQuantityDetails", "unit", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_17_Order_QuantityIntervalSection_VolumeQuantity_OneMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_18_Order_QuantityIntervalSection_PriceCurency_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "value", "")
                .EditTradeNode("priceIntervalQuantityDetails", "currency", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_18_Order_QuantityIntervalSection_PriceCurency_OneMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "currency", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_19_Order_SameQuantityIntervalSection_Price_BothAppearing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceTimeIntervalQuantity", "value", "40")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_19_Order_SameQuantityIntervalSection_Price_SamePriceMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceTimeIntervalQuantity", "value", "40")
                .EditTradeNode("price", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        public void CFV_20()
        {
            storeResults = true;
            //TODO
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_21_Order_VolumeQuantity_BothPopulated()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "100")
                .EditTradeNode("quantity", "101")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_21_Order_VolumeQuantity_NeitherPopulated()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "")
                .EditTradeNode("quantity", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_21_Order_VolumeQuantity_SamePriceNull()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceTimeIntervalQuantity", "value", "40")
                .EditTradeNode("quantity", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_22_Order_AuctionVolumeQuantity_BothPopulated()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "100")
                .EditTradeNode("quantity", "101")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_22_Order_AuctionVolumeQuantity_NeitherPopulated()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "")
                .EditTradeNode("quantity", "")
                .EditTradeNode("contractType", "AU")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_22_Order_AuctionVolumeQuantity_SamePriceNull()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceTimeIntervalQuantity", "value", "40")
                .EditTradeNode("quantity", "")
                .EditTradeNode("contractType", "AU")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_23_Order_TraderID_OrganisedMarketID_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("traderIdForMarketParticipant", "")
                .EditTradeNode("organisedMarketPlaceIdentifier", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_23_Order_TraderID_OrganisedMarketID_OneMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("traderIdForMarketParticipant", "asd")
                .EditTradeNode("organisedMarketPlaceIdentifier", "asd")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_24_Order_OrganisedMarketPlace_Contract_Combination()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("mic", "BIL")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_25_Order_Currency_NotAllowed()
        {
            storeResults = true;
            CreateImportFile.GenXMLOrder();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceCurrency", "BGN")
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
