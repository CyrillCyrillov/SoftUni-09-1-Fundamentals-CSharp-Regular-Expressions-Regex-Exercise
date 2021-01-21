using System;
using System.Text.RegularExpressions;

namespace Task03_SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?([0-9]*\.?[0-9]+)\$";

            Regex extractInfo = new Regex(pattern);

            double totallMoney = 0;

            while (true)
            {
                string nextLine = Console.ReadLine();

                if(nextLine.ToUpper() == "END OF SHIFT")
                {
                    break;
                }

                Match validInfo = extractInfo.Match(nextLine);

                if (validInfo.Success)
                {
                    string customer = validInfo.Groups[1].Value;
                    string product = validInfo.Groups[2].Value;
                    int quanttity = int.Parse(validInfo.Groups[3].Value);
                    double price = double.Parse(validInfo.Groups[4].Value);

                    totallMoney += quanttity * price;

                    Console.WriteLine($"{customer}: {product} - {(quanttity * price):f2}");
                }
            }


            Console.WriteLine($"Total income: {totallMoney:f2}");
        }
    }
}
