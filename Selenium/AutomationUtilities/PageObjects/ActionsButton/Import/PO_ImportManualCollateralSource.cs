using AutomationUtilities.Commands;
using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ImportManualCollateralSource
    {
        public PO_ImportManualCollateralSource()
        {

            Thread.Sleep(2000);
            String expectedPage = "Import Collaterals By Source Setting";
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

        public ImportCollateralXML ImportCollateralGenericXML()
        {
            return new ImportCollateralXML();
        }

        public void VerifyFileIsUploaded()
        {
            Util.CheckIfTextPresented("read into Elements and marked as ready for import.");
        }

        public ImportCollateralTREMIR ImportCollateralTREMIR()
        {
            return new ImportCollateralTREMIR();
        }
    }
}
