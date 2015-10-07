using SampleFileGenerator.AutoGenerate;
using SampleFileGenerator.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string outpiteFile = @"C:\Test_VanillaTrades.xml";
            //string outpiteFile = @"C:\Test_Futures.xml";
            //string outpiteFile = @"C:\Test_VanillaPositions.xml";
            //string outpiteFile = @"C:\Test_CommodityOptions.xml";
            //string outpiteFile = @"C:\Test_CurrencyOptions.xml";
            //string outpiteFile = @"C:\Test_InterestRateOptions.xml";
            //string outpiteFile = @"C:\Test_VanillaTradesDelegation.xml";
            //string outpiteFile = @"C:\Test_MifidOptions.xml";

            AutoFileGenerator gen = new AutoFileGenerator();

            Console.WriteLine("Start Generating...");
            Console.WriteLine(DateTime.Now);

            gen.GenerateSingleFile(outpiteFile, ProductType.VanillaTrades, 100);
            //gen.GenerateSingleFile(outpiteFile, ProductType.Futures, 100);
            //gen.GenerateSingleFile(outpiteFile, ProductType.VanillaPositions, 10);
            //gen.GenerateSingleFile(outpiteFile, ProductType.CommodityOptions, 10);
            //gen.GenerateSingleFile(outpiteFile, ProductType.CurrencyOptions, 10);
            //gen.GenerateSingleFile(outpiteFile, ProductType.InterestRateOptions, 10);
            //gen.GenerateSingleFile(outpiteFile, ProductType.VanillaTradesDelegation, 10);
            //gen.GenerateSingleFile(outpiteFile, ProductType.MifidOptions, 10);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("File {0} generated successfully.", outpiteFile);

            Console.ReadLine();
        }
    }
}
