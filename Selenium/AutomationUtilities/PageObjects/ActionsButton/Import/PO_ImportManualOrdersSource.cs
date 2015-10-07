using AutomationUtilities.Commands;
using AutomationUtilities.Exceptions;
using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.ActionsButton.Import
{
    public class PO_ImportManualOrdersSource
    {
        public PO_ImportManualOrdersSource()
        {

            Thread.Sleep(2000);
            String expectedPage = "Import Orders By Source Setting";
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


        public ImportGeneralXML ImportREMITGeneralXMLWith()
        {
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.REMIT_GenXML_Order);
            return new ImportGeneralXML();
        }

        public void VerifyFileIsUploaded()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("read into Elements and marked as ready for import.");
        }

        public void VerifyTransformError()
        {
            Thread.Sleep(2000);
            Util.CheckIfTextPresented("Transform error");
        }
    }
}
