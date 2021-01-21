using System;
using System.Text.RegularExpressions;

namespace Task01_Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d*)!(\d+)";

            Regex chek = new Regex(pattern);

            double spendMoney = 0;
            
            string nextInputLine = Console.ReadLine();
            
            Console.WriteLine("Bought furniture:");

            while (nextInputLine.ToUpper() != "PURCHASE")
            {
                
                Match validDatas = chek.Match(nextInputLine);

                if(validDatas.Success)
                {
                    string nextFurniture = validDatas.Groups[1].Value;
                    double nextPrice = double.Parse(validDatas.Groups[2].Value);
                    int nextQuantitty = int.Parse(validDatas.Groups[3].Value);

                    spendMoney += nextPrice * nextQuantitty;

                    Console.WriteLine(nextFurniture);

                }

                 nextInputLine = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}
