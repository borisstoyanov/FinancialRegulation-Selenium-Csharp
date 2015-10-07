using AutomationUtilities.Commands;
using AutomationUtilities.Exceptions;
using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ImportManualTradeSource
    {
        public PO_ImportManualTradeSource()
        {

            Thread.Sleep(2000);    
            String expectedPage = "Import Trades By Source Setting";
            String actualPage = Browser.Browser.Instance.Title.ToString();

                try
                {

                    if (!expectedPage.Equals(actualPage))
                    {
                        throw new NotOnTheExpectedPageException(expectedPage, actualPage);
                    }
                }
                catch (NotOnTheExpectedPageException e)
                {
                    Test.verificationErrors.Append(e);
                    Assert.Fail("The page displayed is not as the expected one. \nExpected this: " + e.getExpectedPage() + "\nbut got this: " + e.getActualPage());
                }
            

        }


        public static void SelectFile(string file)
        {
            Util.WaitForElementPresentByXPath("//input[@name='uploadFile']", 15);
            Browser.Browser.Instance.FindElement(By.Name("uploadFile")).SendKeys(file);
            
        }


        public ImportGeneralXML ImportGeneralXMLWith()
        {
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.GenXML_Trade);
            return new ImportGeneralXML();
        }

        public ImportTREMIRFile ImportTREMIRFileR010()
        {
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.TREMIR_R010_Trade);
            return new ImportTREMIRFile();
        }

        public static void clickImport()
        {
            Browser.Browser.ClickByID("Import");
        }

        public static void SelectSourceSettingValueContaining(string value)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("EMIRSourceSetting"))).SelectByText(value);
        }

        public void VerifyFileIsUploaded()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("read into Elements and marked as ready for import.");
        }



        public ImportTREMIRFile ImportTREMIRFileR001()
        {
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.TREMIR_R001_Position);
            return new ImportTREMIRFile();
        }

        public ImportGeneralXML ImportREMITGeneralXMLWith()
        {
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.REMIT_GenXML_Trade);
            return new ImportGeneralXML();
        }

        public void VerifyTransformError()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Transform error");
        }
    }
}
