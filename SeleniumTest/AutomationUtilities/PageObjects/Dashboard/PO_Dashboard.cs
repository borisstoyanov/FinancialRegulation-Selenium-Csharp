using AutomationUtilities.Exceptions;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.PageObjects.ExtRefInOut;
using AutomationUtilities.PageObjects.ImportManualSourcePO;
using AutomationUtilities.PageObjects.LegalEntities;
using AutomationUtilities.PageObjects.Markets;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.PageObjects.SendPO;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using AutomationUtilities.PageObjects.Maintanance.ReferenceData.ISINCodes;
using AutomationUtilities.PageObjects.ReferenceData.InitiatorAggressor;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.EicCodes;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer;
using AutomationUtilities.PageObjects.ActionsButton.Import;

namespace AutomationUtilities.PageObjects
{
    public class PO_Dashboard
    {
        public PO_Dashboard()
        {
            Util.WaitForElementVisibleByXPath("//div[@id='History']", 300);
            String expectedPage = "Dashboard";
            String actualPage = Browser.Browser.Instance.Title.ToString();

            try
            {

                if (!actualPage.Contains(expectedPage))
                {
                    throw new NotOnTheExpectedPageException(expectedPage, actualPage);
                }
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one. \nExpected this: " + e.getExpectedPage() + "\nbut got this: " + e.getActualPage());
                Test.TearDown(true);

            }
        }
        public static PO_ImportManualTradeSource GoToImportTradeManualSource()
        {
            PO_ActionButton.GoToImportTradeBySource();
            return new PO_ImportManualTradeSource();
        }

        public static PO_ImportManualCollateralSource GoToImportCollateralManualSource()
        {
            PO_ActionButton.GoToImportCollateralBySource();
            return new PO_ImportManualCollateralSource();
        }

        public static PO_ImportManualValuationSource GoToImportValuationManualSource()
        {
            PO_ActionButton.GoToImportValuationBySource();
            return new PO_ImportManualValuationSource();
        }

        public static PO_ExtRefIn_PopUp GoToExternalRefIns()
        {
            PO_MaintenenceButton.GoToExternalRefIns();
            return new PO_ExtRefIn_PopUp();
        }

        public static PO_ExtRefOut_PopUp GoToExternalRefOuts()
        {
            PO_MaintenenceButton.GoToExternalRefOuts();
            return new PO_ExtRefOut_PopUp();
        }

        public static PO_CounterParties_PopUp GoToCounterPartiesPopUp()
        {
            PO_MaintenenceButton.GoToCounterParties();
            return new PO_CounterParties_PopUp();
        }

        public static PO_ProductsPopUp GoToProducts()
        {
            PO_MaintenenceButton.GoToProducts();
            return new PO_ProductsPopUp();
        }
        
        public static void Close()
        {
            Browser.Browser.ClickByXPath("//button[@class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only']");
            Thread.Sleep(3000);
        }

        public static PO_EMIRQueue GoToEMIRConfiguredQueue(string workQueueName)
        {
            Util.WaitForElementVisibleByXPath("//div[@title='Click for " + workQueueName + " Work Queue List']", 15);
            Browser.Browser.ClickByXPath("//div[@title='Click for " + workQueueName + " Work Queue List']");
            return new PO_EMIRQueue(workQueueName);
        }

        public static void GoTo()
        {
            Browser.Browser.Instance.Navigate().GoToUrl("https://" + Test.instanceURL + "/Home/EMIRWorkQueueSummary");
        }

        public static PO_SendTradesByTargetSetting GoToSendTradesByTargetSetting()
        {
            PO_ActionButton.GoToSendTradesByTargetSetting();
            return new PO_SendTradesByTargetSetting();
        }

        public static PO_SendCollaterals GoToSendCollateralsByTargetSetting()
        {
            PO_ActionButton.GoToSendCollateralsByTargetSetting();
            return new PO_SendCollaterals();
        }

        public static PO_SendValuations GoToSendValuationsByTargetSetting()
        {
            PO_ActionButton.GoToSendValuationsByTargetSetting();
            return new PO_SendValuations();
        }

        public static void LogOff()
        {
            PO_UserAccountButton.LogOff();
        }

        public PO_StaticEntitiesAwaitingApproval GoToStaticEntitiesAwaitingApproval()
        {
            Browser.Browser.ClickByXPath("//a[text()='Approvals Queues']");
            Browser.Browser.ClickByXPath("//div[text()='All static outstanding.']");
            return new PO_StaticEntitiesAwaitingApproval();
        }


        public static PO_ManageWorkQueues GoToManageWorkQueuesTrades()
        {
            PO_ActionButton.GoToManageWorkQueuesTrades();
            return new PO_ManageWorkQueues();
        }

        public static PO_AddessesPopUp GoToAddressesPopUp()
        {
            PO_MaintenenceButton.GoToAddresss();
            return new PO_AddessesPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToActionTypesPopUp()
        {
            PO_MaintenenceButton.GoToActionTypes();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_TenantsPopUp GoToTenantsPopUp()
        {
            PO_MaintenenceButton.GoToTenants();
            return new PO_TenantsPopUp();
        }


        public static PO_OperationsPopUp GoToOperationsPopUp()
        {
            PO_MaintenenceButton.GoToOperations();
            return new PO_OperationsPopUp();
        }

        public static PO_EntityLocksPopUp GoToEntityLocksPopUp()
        {
            PO_MaintenenceButton.GoToEntityLocks();
            return new PO_EntityLocksPopUp();
        }

        public static PO_RegenerateWorkQueuesPopUp GoToRegenerateWorkQueuesPopUp()
        {
            PO_MaintenenceButton.GoToRegenerateWorkQueues();
            return new PO_RegenerateWorkQueuesPopUp();
        }

        public static PO_ActionTypesPopUp GoToSystemActionTypesPopUp()
        {
            PO_MaintenenceButton.GoToSystemActionTypes();
            return new PO_ActionTypesPopUp();
        }

        public static PO_SourceSettingsPopUp GoToSourceSettingsPopUp()
        {
            PO_MaintenenceButton.GoToSourceSettingsTypes();
            return new PO_SourceSettingsPopUp();
        }

        public static PO_ResponseSettingsPopUp GoToResponseSettingsPopUp()
        {
            PO_MaintenenceButton.GoToResponseSettingsTypes();
            return new PO_ResponseSettingsPopUp();
        }

        public static PO_ChannelFileMasksPopUp GoToChannelFileMasksPopUp()
        {
            PO_MaintenenceButton.GoToChannelFileMasks();
            return new PO_ChannelFileMasksPopUp();
        }

        public static PO_FTPChannelSettingsPopUp GoToFTPChannelSettingsPopUp()
        {
            PO_MaintenenceButton.GoToFTPChannelSettings();
            return new PO_FTPChannelSettingsPopUp();
        }

        public static PO_MessageTypesPopUp GoToMessageTypesPopUp()
        {
            PO_MaintenenceButton.GoToMessageTypes();
            return new PO_MessageTypesPopUp();
        }

        public static PO_RegulationsPopUp GoToRegulationsPopUp()
        {
            PO_MaintenenceButton.GoToRegulations();
            return new PO_RegulationsPopUp();
        }

        public static PO_TradeRepositoriesPopUp GoToTradeRepositoriesPopUp()
        {
            PO_MaintenenceButton.GoToTradeRepositories();
            return new PO_TradeRepositoriesPopUp();
        }

        public static PO_TradeRepositoryAccountsPopUp GoToTradeRepositoryAccountsPopUp()
        {
            PO_MaintenenceButton.GoToTradeRepositoryAccounts();
            return new PO_TradeRepositoryAccountsPopUp();
        }

        public static PO_TransactionTypesPopUp GoToTransactionTypePopUp()
        {
            PO_MaintenenceButton.GoToTransactionTypesTypes();
            return new PO_TransactionTypesPopUp();
        }

        public static PO_TargetSettingsPopUp GoToTargetSettingsPopUp()
        {
            PO_MaintenenceButton.GoToTargetSettings();
            return new PO_TargetSettingsPopUp();
        }

        public static PO_SourceSystemsPopUp GoToSourceSystemPopUp()
        {
            PO_MaintenenceButton.GoToSourceSystems();
            return new PO_SourceSystemsPopUp();
        }

        public static PO_WorkQueueCategoriesPopUp GoToWorkQueueCategoriesPopUp()
        {
            PO_MaintenenceButton.GoToWorkQueueCategories();
            return new PO_WorkQueueCategoriesPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToClearedPopUp()
        {
            PO_MaintenenceButton.GoToCleared();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToClearingObligationsPopUp()
        {
            PO_MaintenenceButton.GoToClearingObligations();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToClearingThresholdsPopUp()
        {
            PO_MaintenenceButton.GoToClearingThreshold();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCollateralisationsPopUp()
        {
            PO_MaintenenceButton.GoToCollateralisation();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCollateralPortfoliosPopUp()
        {
            PO_MaintenenceButton.GoToCollateralPortfolios();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCommercialActivitiesPopUp()
        {
            PO_MaintenenceButton.GoToCommercialActivities();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCommodityBasesPopUp()
        {
            PO_MaintenenceButton.GoToCommodityBase();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_CommodityDetail_PopUp GoToCommodityDetailsPopUp()
        {
            PO_MaintenenceButton.GoToCommodityDetail();
            return new PO_CommodityDetail_PopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCompressionsPopUp()
        {
            PO_MaintenenceButton.GoToCompressions();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToConfirmationMeansPopUp()
        {
            PO_MaintenenceButton.GoToConfirmationMeans();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCorporateSectorsPopUp()
        {
            PO_MaintenenceButton.GoToCorporateSectors();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCounterpartySidesPopUp()
        {
            PO_MaintenenceButton.GoToCounterpartySides();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToCountriesPopUp()
        {
            PO_MaintenenceButton.GoToCounterpartySides();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_CurrencyPopUp GoToCurrenciesPopUp()
        {
            PO_MaintenenceButton.GoToCurrencies();
            return new PO_CurrencyPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToDeliveryTypesPopUp()
        {
            PO_MaintenenceButton.GoToDeliveryTypes();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToDerivativeClassesPopUp()
        {
            PO_MaintenenceButton.GoToDerivativeClasses();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToETDIndicatorsPopUp()
        {
            PO_MaintenenceButton.GoToETDIndicators();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToExerciseStylesPopUp()
        {
            PO_MaintenenceButton.GoToExerciseStyles();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToFinancialNaturesPopUp()
        {
            PO_MaintenenceButton.GoToFinancialNatures();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToFrequencyPopUp()
        {
            PO_MaintenenceButton.GoToFrequency();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_InitiatorAggressorPopUp GoToInitiatorAggressorPopUp()
        {
            PO_MaintenenceButton.GoToInitiatorAggressor();
            return new PO_InitiatorAggressorPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToIntragroupsPopUp()
        {
            PO_MaintenenceButton.GoToIntragroups();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ISINCodes_PopUp GoToISINCodesPopUp()
        {
            PO_MaintenenceButton.GoToISINCodes();
            return new PO_ISINCodes_PopUp();
        }

        public static PO_ReferenceDatasPopUp GoToLifecycleEventsPopUp()
        {
            PO_MaintenenceButton.GoToLifecycleEvents();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToLoadTypesPopUp()
        {
            PO_MaintenenceButton.GoToLoadType();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToMasterAgreementsPopUp()
        {
            PO_MaintenenceButton.GoToMasterAgreements();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToNonEEAsPopUp()
        {
            PO_MaintenenceButton.GoToNonEEAs();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToOptionTypesPopUp()
        {
            PO_MaintenenceButton.GoToOptionType();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToProductTaxonomysPopUp()
        {
            PO_MaintenenceButton.GoToProductTaxonomy();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToRateDayCountsPopUp()
        {
            PO_MaintenenceButton.GoToRateDayCount();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToTradingCapacitiesPopUp()
        {
            PO_MaintenenceButton.GoToTradingCapacities();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToUnderlyingTypesPopUp()
        {
            PO_MaintenenceButton.GoToUnderlyingType();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToValuationSourcesPopUp()
        {
            PO_MaintenenceButton.GoToValuationSources();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_ReferenceDatasPopUp GoToValuationTypesPopUp()
        {
            PO_MaintenenceButton.GoToValuationTypes();
            return new PO_ReferenceDatasPopUp();
        }

        public static PO_BICPopUp GoToBICPopUp()
        {
            PO_MaintenenceButton.GoToBICCodes();
            return new PO_BICPopUp();
        }

        public static PO_EICPopUp GoToEICPopUp()
        {
            PO_MaintenenceButton.GoToEICCodes();
            return new PO_EICPopUp();
        }

        public static PO_LegalEntities GoToLegalEntities()
        {
            PO_MaintenenceButton.GoToLegalEntities();
            return new PO_LegalEntities();
        }

        public static PO_MarketsPopUp GoToMarkets()
        {
            PO_MaintenenceButton.GoToMarkets();
            return new PO_MarketsPopUp();
        }

        public static PO_ImportProductManualSource GoToImportProductManualSource()
        {
            PO_ActionButton.GoToImportProduct();
            return new PO_ImportProductManualSource();
        }

        public static PO_SendTradesByTradeRepo GoToSendTradesByTradeRepo()
        {
            PO_ActionButton.GoToSendTradesByTradeRepo();
            return new PO_SendTradesByTradeRepo();
        }

        public static PO_EMIRSettings GoToEMIRSettingsPopUp()
        {
            PO_MaintenenceButton.GoToEMIRSettings();
            return new PO_EMIRSettings();
        }

        public static PO_ManageExtRefIn GoToManageRefIns()
        {
            PO_ActionButton.GoToManageRefIns();
            return new PO_ManageExtRefIn();
        }

        public PO_StaticMappingsAwaitingApproval GoToStaticMappingsAwaitingApproval()
        {
            Browser.Browser.ClickByXPath("//a[text()='Approvals Queues']");
            Browser.Browser.ClickByXPath("//div[text()='All static mappings.']");
            return new PO_StaticMappingsAwaitingApproval();
        }

        public PO_DashboardStatuses DailyValuations()
        {
            return new PO_DashboardStatuses("DailyValuations");
        }

        public PO_DashboardStatuses DailyTrades()
        {
            return new PO_DashboardStatuses("Actions");
        }

        public PO_DashboardStatuses DailyCollateral()
        {
            return new PO_DashboardStatuses("DailyCollateral");
        }

        public PO_DashboardConfiguredQueuesTabs ConfiguredQueue()
        {
            return new PO_DashboardConfiguredQueuesTabs();
        }

        public PO_Dashboard ClickHomeRegulationButton()
        {
            Browser.Browser.ClickByXPath("//a[contains(@href,'WorkQueueSummary')]");
            return new PO_Dashboard();
        }

        public void CheckHistory()
        {
            if (!Test.TransactionReference.Equals(null))
            {
                Browser.Browser.ClickByID("History");
                Util.WaitForElementVisibleByXPath("//span[contains(text(),'" + Test.UTI + "')]", 15);
            }
            else
            {
                Assert.Fail("In order to check History, User should visit an Edit Transaction page prior executing this method.");
            }
        }

        public static Audit.PO_AuditResponsesPopUp GoToAuditResponses()
        {
            PO_ActionButton.GoToAuditResponses();
            return new Audit.PO_AuditResponsesPopUp();
        }

        public static Audit.PO_AuditApprovalsPopUp GoToAuditApprovals()
        {
            PO_ActionButton.GoToAuditApprovals();
            return new Audit.PO_AuditApprovalsPopUp();
        }

        public static Audit.PO_AuditCollateralsPopUp GoToAuditCollaterals()
        {
            PO_ActionButton.GoToAuditCollaterals();
            return new Audit.PO_AuditCollateralsPopUp();
        }

        public static Audit.PO_AuditInboundPopUp GoToAuditInbound()
        {
            PO_ActionButton.GoToAuditInbound();
            return new Audit.PO_AuditInboundPopUp();
        }

        public static Audit.PO_AuditOutboundPopUp GoToAuditOutbound()
        {
            PO_ActionButton.GoToAuditOutbound();
            return new Audit.PO_AuditOutboundPopUp();
        }

        public static Audit.PO_AuditTradePopUp GoToAuditTrade()
        {
            PO_ActionButton.GoToAuditTrade();
            return new Audit.PO_AuditTradePopUp();
        }

        public static Audit.PO_AuditValuationPopUp GoToAuditValuation()
        {
            PO_ActionButton.GoToAuditValuation();
            return new Audit.PO_AuditValuationPopUp();
        }

        public static ActionsButton.Manage.PO_ExtRefIns_Promote GoToExternalRefInsPromote()
        {
            PO_ActionButton.GoToExternalRefInsPromote();
            return new ActionsButton.Manage.PO_ExtRefIns_Promote();
        }

        public static PO_ProductContractSeriesPopUp GoToProductContractSer()
        {
            PO_MaintenenceButton.GoToProductContractSer();
            return new PO_ProductContractSeriesPopUp();
        }

        public static PO_ImportManualOrdersSource GoToImportOrdersManualSource()
        {
            PO_ActionButton.GoToImportOrdersBySource();
            return new PO_ImportManualOrdersSource();
        }
    }
}
