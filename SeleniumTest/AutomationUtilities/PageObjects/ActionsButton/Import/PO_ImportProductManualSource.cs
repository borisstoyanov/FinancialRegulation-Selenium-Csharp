using AutomationUtilities.Commands;
using AutomationUtilities.Exceptions;
using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.ImportManualSourcePO
{
    public class PO_ImportProductManualSource
    {
        public PO_ImportProductManualSource()
        {

            Thread.Sleep(2000);
            Util.WaitForElementVisibleByXPath("//input[@name='uploadFile']", 15);
            String expectedPage = "Import Products By Source Setting";
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


        public ImportProduct_GeneralXML ImportGeneralXMLWith()
        {
            return new ImportProduct_GeneralXML();
        }

        public ImportProduct_CSVImporter ImportCSVImporter()
        {
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.Product_CSVImporter);
            return new ImportProduct_CSVImporter();
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
            Util.CheckIfTextPresented("File " + Test.fileName + ": read into Elements and marked as ready for import.");
        }
    }
}
