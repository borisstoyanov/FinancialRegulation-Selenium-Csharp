using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemitAutomation.Utils;

namespace RemitAutomation.Tests.Actions.ImportTrade.CrossFieldValidation
{
    [TestClass]
    public class TTradeCrossFieldValidationTests : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITUser();
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_1_Trade_Options()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("derivativeType", "Options")
                .EditTradeNode("tradeReport", "optionStyle", "")
                .EditTradeNode("contract", "optionStyle", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_2_Trade_ExerciseDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_3_Trade_DeliveryZone_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("tradeReport", "deliveryPointOrZone", "")
                .EditTradeNode("contract", "deliveryPointOrZone", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_4_Trade_DeliveryZone_Unbounded()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("TradeReport", "deliveryPointOrZone", "AutomationUnboundedZone")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_5_Trade_BuyAndSell()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("buySellIndicator", "C")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_5_Trade_BuyOrSell()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("buySellIndicator", "B")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_6_Trade_TransactionTime()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "2015-08-30T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15, "'Last Trading Date Time' need to be on or prior to the delivery Start Date");
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_6_Trade_TransactionTime_AfterLastTradingDateTime()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("TradeReport", "transactionTime", "2015-08-30T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_7_Trade_TransactionTime_AfterDeliveryStartDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "")
                .EditTradeNode("TradeReport", "transactionTime", "2015-07-31T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_8_Trade_TransactionTime_AfterDeliveryStartDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "")
                .EditTradeNode("TradeReport", "transactionTime", "2015-07-31T12:00:00+02:00")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15, "Last Trading Date Time' need to be on or prior to the delivery Start Date");
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_9_Trade_TransactionDate_AfterDeliveryEndDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("lastTradingDateTime", "")
                .EditTradeNode("TradeReport", "transactionTime", "2015-07-31T12:00:00+02:00")
                .EditTradeNode("deliveryEndDate", "2015-07-30")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_10_Trade_DeliveryStart_AfterDeliveryEndDate()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_11_Trade_DeliveryStart_AfterDeliveryEndTime()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_12_Trade_PriceIntervals_Overlap()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("daysOfTheWeek", "Tue456")
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
        public void CFV_13_Trade_SettlementMethod_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("contract", "settlementMethod", "")
                .EditTradeNode("tradeReport", "settlementMethod", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_14_Trade_OptionType_Unlinked()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_14_Trade_OptionStyle_Unlinked()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_15_Trade_VolumeQuantity_Unit()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("tradeReport", "value", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_15_Trade_VolumeQuantity_Unit_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("tradeReport", "value", "")
                .EditTradeNode("tradeReport", "unit", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_16_Trade_PriceDetails_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("tradeReport", "price", "")
                .EditTradeNode("tradeReport", "priceCurrency", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_16_Trade_PriceDetails_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("tradeReport", "price", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_17_Trade_QuantityIntervalSection_VolumeQuantity_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_17_Trade_QuantityIntervalSection_VolumeQuantity_OneMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_18_Trade_QuantityIntervalSection_PriceCurency_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_18_Trade_QuantityIntervalSection_PriceCurency_OneMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_19_Trade_SameQuantityIntervalSection_Price_BothAppearing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_19_Trade_SameQuantityIntervalSection_Price_SamePriceMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_20_Trade_VolumeQuantity_BothPopulated()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceIntervalQuantityDetails", "quantity", "100")
                .EditTradeNode("TradeReport", "quantity", "101")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void CFV_23_Trade_TraderID_OrganisedMarketID_BothMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_23_Trade_TraderID_OrganisedMarketID_OneMissing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("TradeReport", "traderIdForMarketParticipant", "asd")
                .EditTradeNode("TradeReport", "organisedMarketPlaceIdentifier", "asd")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void OK_CFV_24_Trade_OrganisedMarketPlace_Contract_Combination()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
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
        public void CFV_25_Trade_Currency_NotAllowed()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("TradeReport", "priceCurrency", "BGN")
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
