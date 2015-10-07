using System;

namespace AutomationUtilities.FieldIDs
{
    public class ProductInputFields
    {
        public const String EMIRProduct_Name = "EMIRProduct_Name";
        public const String EMIRProduct_BloombergCode = "EMIRProduct_BloombergCode";
        public const String EMIRProduct_UPI = "EMIRProduct_UPI";
        public const String EMIRProduct_ISIN = "EMIRProduct_ISIN";
        public const String EMIRProduct_AII = "EMIRProduct_AII";
        public const String EMIRProduct_CFI = "EMIRProduct_CFI";
        public const String EMIRProduct_PriceMultiplier = "EMIRProduct_PriceMultiplier";
        public const String EMIRProduct_Underlying = "EMIRProduct_Underlying";
        /// <summary>
        /// Date format should be as it follows: DD/MM/YYYY. 
        /// Construct your date argument like this:
        /// Test.testdate.Day + "/" + Test.testdate.Month + "/" + Test.testdate.Year
        /// </summary>
        public const String MaturityDate = "MaturityDate";
    }
}
