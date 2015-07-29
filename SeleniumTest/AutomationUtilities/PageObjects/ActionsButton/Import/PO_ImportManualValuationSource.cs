using AutomationUtilities.Commands;
using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_ImportManualValuationSource
    {
        public PO_ImportManualValuationSource()
        {

            Thread.Sleep(2000);
            String expectedPage = "Import Valuations By Source Setting";
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

        public ImportValuationXML ImportValuationGenericXML()
        {
            return new ImportValuationXML();
        }

        public void VerifyFileIsUploaded()
        {
            Util.CheckIfTextPresented("read into Elements and marked as ready for import.");
        }

        public ImportValuationTREMIR_R002 ImportValuationTREMIR_R002()
        {
            return new ImportValuationTREMIR_R002();
        }
    }
}
