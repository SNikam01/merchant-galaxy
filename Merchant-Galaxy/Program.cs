using Merchant_Galaxy.Common;
using Merchant_Galaxy.Interfaces;
using Merchant_Galaxy.Roman;
using System;
using System.IO;

namespace Merchant_Galaxy {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("--- ROMAN TO DECIMAL CONVERTER --- ");
            Console.WriteLine();

            string path =  System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetEntryAssembly().Location);

            // Open the file to read from.
            string readText = File.ReadAllText(path);
            string[] lines = readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("--- Input Start ---");
            Console.WriteLine(readText);
            Console.WriteLine("--- Input End ---");

            Console.WriteLine();
            Console.WriteLine("--- Output Start ---");

            #region "Initialize required components for the convertions"

            AliasMapper aliasMap = new AliasMapper();
            IDecimalConverter converter = new RomanConverter();
            CommodityIndex commodityIndex = new CommodityIndex();

            #endregion

            ExpressionParser parser = new ExpressionParser(aliasMap, converter, commodityIndex);
            foreach (string line in lines) {
                parser.Parse(line);
            }

            Console.WriteLine("--- Output End ---");
            Console.ReadLine();
        }
    }
}
