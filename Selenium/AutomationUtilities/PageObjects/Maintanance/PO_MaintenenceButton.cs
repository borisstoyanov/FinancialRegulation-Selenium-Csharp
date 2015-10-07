using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    class PO_MaintenenceButton
    {
        public static void GoToExternalRefIns()
        {
            Engage();
            ClickBusinessData();
            ClickExternalRefIns();
        }

        private static void ClickExternalRefIns()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Ext Ref Ins']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Ext Ref Ins']");

        }

        private static void ClickBusinessData()
        {
            try
            {
             //   Thread.Sleep(500);

                if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Business data']")))
                {
                    //Thread.Sleep(500);
                    Util.WaitForElementVisibleByXPath("//a[text()='Business data']", 15);
                    Browser.Browser.ClickByXPath("//a[text()='Business data']");
                }
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Test.TearDown(false);
                Assert.Fail("There was an exception in ClickBusinessData\nException: " + Test.verificationErrors);
            }
        }

        private static void ClickReferenceAtoCData()
        {
            Thread.Sleep(500);

            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Reference data']")))
            {
                Thread.Sleep(500);
                Util.WaitForElementVisibleByXPath("//a[text()='Reference data']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Reference data']");

                if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Items A to C']")))
                {
                    Thread.Sleep(500);
                    Util.WaitForElementVisibleByXPath("//a[text()='Items A to C']", 15);
                    Browser.Browser.ClickByXPath("//a[text()='Items A to C']");
                }
            }
        }

        private static void ClickSystemChannels()
        {
            Thread.Sleep(500);

            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='System']")))
            {
                Thread.Sleep(500);
                Util.WaitForElementVisibleByXPath("//a[text()='System']", 15);
                Browser.Browser.ClickByXPath("//a[text()='System']");

                if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Channels']")))
                {
                    Thread.Sleep(500);
                    Util.WaitForElementVisibleByXPath("//a[text()='Channels']", 15);
                    Browser.Browser.ClickByXPath("//a[text()='Channels']");
                }
            }
        }
        
        private static void ClickReferenceDtoLData()
        {
            Thread.Sleep(500);

            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Reference data']")))
            {
                Thread.Sleep(500);
                Util.WaitForElementVisibleByXPath("//a[text()='Reference data']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Reference data']");

                if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Items D to L']")))
                {
                    Thread.Sleep(500);
                    Util.WaitForElementVisibleByXPath("//a[text()='Items D to L']", 15);
                    Browser.Browser.ClickByXPath("//a[text()='Items D to L']");
                }
            }
        }

        private static void ClickReferenceMtoZData()
        {
            Thread.Sleep(500);

            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Reference data']")))
            {
                Thread.Sleep(500);
                Util.WaitForElementVisibleByXPath("//a[text()='Reference data']", 15);
                Browser.Browser.ClickByXPath("//a[text()='Reference data']");

                if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='Items M to Z']")))
                {
                    Thread.Sleep(500);
                    Util.WaitForElementVisibleByXPath("//a[text()='Items M to Z']", 15);
                    Browser.Browser.ClickByXPath("//a[text()='Items M to Z']");
                }
            }
        }

        private static void ClickSystem()
        {
            Thread.Sleep(500);

            if (!Util.IsElementPresent(By.XPath("//a[@class='dcjq-parent active'][text()='System']")))
            {
                Thread.Sleep(500);
                Util.WaitForElementVisibleByXPath("//a[text()='System']", 15);
                Browser.Browser.ClickByXPath("//a[text()='System']");
            }
        }

        
        private static void ClickTrades()
        {
            Thread.Sleep(500);

            if (!Util.IsElementPresent(By.XPath("//div[Text()='EMIR Confirmed']")))
            {
                Thread.Sleep(500);
                Util.WaitForElementVisibleByXPath("//div[Text()='EMIR Confirmed']", 15);
                Browser.Browser.ClickByXPath("//div[Text()='EMIR Confirmed']");
            }
        }

        private static void Engage()
        {
            Browser.Browser.ClickByID("MaintenanceImage");
        }

        public static void GoToExternalRefOuts()
        {
            Engage();
            ClickBusinessData();
            ClickExternalRefOuts();
        }

        private static void ClickExternalRefOuts()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Ext Ref Outs']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Ext Ref Outs']");
        }

        public static void GoToCounterParties()
        {
            Engage();
            ClickBusinessData();
            ClickCounterParties();
        }

        private static void ClickCounterParties()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Counterparties']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Counterparties']");
        }

        public static void GoToProducts()
        {
            Engage();
            ClickBusinessData();
            ClickProducts();
        }

        private static void ClickProducts()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Products']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Products']");
        }

        public static void GoToAddresss()
        {
            Engage();
            ClickBusinessData();
            ClickAddresses();
        }

        public static void GoToActionTypes()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickActionTypes();
        }

        public static void GoToSystemActionTypes()
        {
            Engage();
            ClickSystem();
            ClickSystemActionTypes();
        }

        public static void GoToSourceSettingsTypes()
        {
            Engage();
            ClickSystemChannels();
            ClickSourceSettings();
        }

        public static void GoToResponseSettingsTypes()
        {
            Engage();
            ClickSystemChannels();
            ClickResponseSettings();
        }

        public static void GoToChannelFileMasks()
        {
            Engage();
            ClickSystemChannels();
            ClickChannelFileMasks();
        }
        
        public static void GoToFTPChannelSettings()
        {
            Engage();
            ClickSystemChannels();
            ClickFTPChannelSettings();
        }
        
        public static void GoToMessageTypes()
        {
            Engage();
            ClickSystemChannels();
            ClickMessageTypes();
        }
        
        public static void GoToRegulations()
        {
            Engage();
            ClickSystemChannels();
            ClickRegulations();
        }
        
        public static void GoToTradeRepositories()
        {
            Engage();
            ClickSystemChannels();
            ClickTradeRepositories();
        }
        
        public static void GoToTradeRepositoryAccounts()
        {
            Engage();
            ClickSystemChannels();
            ClickTradeRepositoryAccounts();
        }
        
        public static void GoToTransactionTypesTypes()
        {
            Engage();
            ClickSystemChannels();
            ClickTransactionTypes();
        }
        
        public static void GoToTargetSettings()
        {
            Engage();
            ClickSystemChannels();
            ClickTargetSettings();
        }
        

        public static void GoToSourceSystems()
        {
            Engage();
            ClickSystem();
            ClickSourceSystems();
        }

        public static void GoToWorkQueueCategories()
        {
            Engage();
            ClickSystem();
            ClickWorkQueueCategories();
        }
        
        public static void GoToTenants()
        {
            Engage();
            ClickSystem();
            ClickTenants();
        }

        public static void GoToTrades()
        {
            Engage();
            ClickTrades();
            ClickTenants();
        }

        public static void GoToOperations()
        {
            Engage();
            ClickSystem();
            ClickOperations();
        }

        public static void GoToEntityLocks()
        {
            Engage();
            ClickSystem();
            ClickEntityLocks();
        }

        public static void GoToRegenerateWorkQueues()
        {
            Engage();
            ClickSystem();
            ClickRegenerateWorkQueues();
        }
        
        public static void GoToActionTypesPopUp()
        {
            Engage();
            ClickSystem();
            ClickActionTypes();
        }
        
        public static void GoToCleared()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCleared();
        }

        public static void GoToClearingObligations()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickClearingObligations();
        }

        public static void GoToClearingThreshold()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickClearingThreshold();
        }

        public static void GoToCollateralisation()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCollateralisation();
        }

        public static void GoToCollateralPortfolios()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCollateralPortfolios();
        }

        public static void GoToCommercialActivities()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCommercialActivities();
        }

        public static void GoToCommodityBase()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCommodityBase();
        }

        public static void GoToCommodityDetail()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCommodityDetail();
        }

        public static void GoToCompressions()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCompressions();
        }

        public static void GoToConfirmationMeans()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickConfirmationMeans();
        }

        public static void GoToCorporateSectors()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCorporateSectors();
        }

        public static void GoToCounterpartySides()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCounterpartySides();
        }

        public static void GoToCountries()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCountries();
        }

        public static void GoToCurrencies()
        {
            Engage();
            ClickReferenceAtoCData();
            ClickCurrencies();
        }

        public static void GoToDeliveryTypes()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickDeliveryTypes();
        }

        public static void GoToDerivativeClasses()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickDerivativeClasses();
        }

        public static void GoToETDIndicators()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickETDIndicators();
        }

        public static void GoToExerciseStyles()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickExerciseStyles();
        }

        public static void GoToFinancialNatures()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickFinancialNatures();
        }

        public static void GoToFrequency()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickFrequency();
        }

        public static void GoToInitiatorAggressor()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickInitiatorAggressor();
        }

        public static void GoToIntragroups()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickIntragroups();
        }

        public static void GoToISINCodes()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickISINCodes();
        }

        public static void GoToLifecycleEvents()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickLifecycleEvents();
        }

        public static void GoToLoadType()
        {
            Engage();
            ClickReferenceDtoLData();
            ClickLoadType();
        }

        public static void GoToMasterAgreements()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickMasterAgreements();
        }

        public static void GoToNonEEAs()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickNonEEAs();
        }

        public static void GoToOptionType()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickOptionType();
        }

        public static void GoToProductTaxonomy()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickProductTaxonomy();
        }

        public static void GoToRateDayCount()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickRateDayCount();
        }

        public static void GoToTradingCapacities()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickTradingCapacities();
        }

        public static void GoToUnderlyingType()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickUnderlyingType();
        }

        public static void GoToValuationSources()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickValuationSources();
        }

        public static void GoToValuationTypes()
        {
            Engage();
            ClickReferenceMtoZData();
            ClickValuationTypes();
        }

        public static void GoToEMIRSettings()
        {
            Engage();
            ClickSystem();
            ClickEMIRSettings();
        }
        
        private static void ClickAddresses()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Addresses']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Addresses']");
        }

        private static void ClickActionTypes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Action Types']");
        }

        private static void ClickEMIRSettings()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='EMIR Settings']");
        }

        private static void ClickTenants()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Tenants']");
        }

        private static void ClickOperations()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Operations']");
        }

        private static void ClickEntityLocks()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Entity Locks']");
        }

        private static void ClickRegenerateWorkQueues()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Regenerate Work Queues']");
        }
        
        private static void ClickSystemActionTypes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Action Types']");
        }

        private static void ClickSourceSettings()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Source Settings']");
        }

        private static void ClickResponseSettings()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Response Settings']");
        }

        private static void ClickChannelFileMasks()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Channel File Masks']");
        }
        
        private static void ClickFTPChannelSettings()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='FTP Channel Settings']");
        }
        
        private static void ClickMessageTypes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Message Type']");
        }
        
        private static void ClickRegulations()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Regulations']");
        }
        
        private static void ClickTradeRepositories()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Trade Repositories']");
        }

        private static void ClickTradeRepositoryAccounts()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Trade Repository Accounts']");
        }
        
        private static void ClickTransactionTypes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Transaction Type']");
        }
        
        private static void ClickTargetSettings()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Target Settings']");
        }

        private static void ClickWorkQueueCategories()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Work Queue Categories']");
        }

        private static void ClickSourceSystems()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Source Systems']");
        }

        private static void ClickCleared()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Cleared']");
        }

        private static void ClickClearingObligations()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Clearing Obligations']");
        }

        private static void ClickClearingThreshold()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Clearing Threshold']");
        }

        private static void ClickCollateralisation()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Collateralisations']");
        }

        private static void ClickCollateralPortfolios()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Collateral Portfolios']");
        }

        private static void ClickCommercialActivities()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Commercial Activities']");
        }

        private static void ClickCommodityBase()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Commodity Base']");
        }

        private static void ClickCommodityDetail()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Commodity Detail']");
        }

        private static void ClickCompressions()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Compressions']");
        }
        
        private static void ClickConfirmationMeans()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Confirmation Means']");
        }

        private static void ClickCorporateSectors()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Corporate Sectors']");
        }

        private static void ClickCounterpartySides()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Counterparty Sides']");
        }

        private static void ClickCountries()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Countries']");
        }

        private static void ClickCurrencies()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsAtoC']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsAtoC']//a[text()='Currencies']");
        }

        private static void ClickDeliveryTypes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Delivery Types']");
        }

        private static void ClickDerivativeClasses()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Derivative Classes']");
        }

        private static void ClickETDIndicators()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='ETD Indicators']");
        }

        private static void ClickExerciseStyles()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Exercise Styles']");
        }

        private static void ClickFinancialNatures()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Financial Natures']");
        }

        private static void ClickFrequency()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Frequency']");
        }

        private static void ClickInitiatorAggressor()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Initiator Aggressor']");
        }

        private static void ClickIntragroups()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Intragroups']");
        }

        private static void ClickISINCodes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='ISIN Codes']");
        }

        private static void ClickLifecycleEvents()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Lifecycle Events']");
        }

        private static void ClickLoadType()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsDtoL']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsDtoL']//a[text()='Load Type']");
        }

        private static void ClickMasterAgreements()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Master Agreements']");
        }

        private static void ClickNonEEAs()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Non EEAs']");
        }

        private static void ClickOptionType()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Option Type']");
        }

        private static void ClickProductTaxonomy()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Product Taxonomy']");
        }

        private static void ClickRateDayCount()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Rate Day Count']");
        }

        private static void ClickTradingCapacities()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Trading Capacities']");
        }

        private static void ClickUnderlyingType()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Underlying Type']");
        }

        private static void ClickValuationSources()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Valuation Sources']");
        }

        private static void ClickValuationTypes()
        {
            Thread.Sleep(500);
            Util.WaitForElementVisibleByXPath("//ul[@id='ItemsMtoZ']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='ItemsMtoZ']//a[text()='Valuation Types']");
        }
        
        internal static void GoToBICCodes()
        {
            Engage();
            ClickBusinessData();
            ClickBicCodes();
        }

        private static void ClickBicCodes()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='BIC Codes']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='BIC Codes']");
        }

        internal static void GoToEICCodes()
        {
            Engage();
            ClickBusinessData();
            ClickEicCodes();
        }

        private static void ClickEicCodes()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='EIC Codes']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='EIC Codes']");
        }

        internal static void GoToLegalEntities()
        {
            Engage();
            ClickBusinessData();
            ClikcLegalEntities();
        }

        private static void ClikcLegalEntities()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Legal Entities']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Legal Entities']");
        }

        internal static void GoToMarkets()
        {
            Engage();
            ClickBusinessData();
            ClickMarkets();
        }

        private static void ClickMarkets()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Markets']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Markets']");
        }

        internal static void GoToProductContractSer()
        {
            Engage();
            ClickBusinessData();
            ClickProductConractSer();
        }

        private static void ClickProductConractSer()
        {
            Util.WaitForElementVisibleByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Product Contract Series']", 15);
            Browser.Browser.ClickByXPath("//ul[@id='DashboardHeadingMenuMaintenance']//a[text()='Product Contract Series']");
        }
    }
}
