using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Task05_Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternHealth = @"[^0123456789+-.\*\/]";
            Regex extractHealth = new Regex(patternHealth);

            string patternDameg = @"[-+]?[0-9]+\.?[0-9]*";   //([+-]?\d+\.?\d?)
               Regex extractDameg = new Regex(patternDameg);

            Dictionary<string, List<double>> heroes = new Dictionary<string, List<double>>();

            string[] names = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string nextName in names)
            {
                MatchCollection healthData = extractHealth.Matches(nextName);
                int health = 0;

                foreach (Match letter in healthData)
                {
                    health += Convert.ToChar(letter.Value);
                }

                //Console.WriteLine(health);

                MatchCollection damegData = extractDameg.Matches(nextName);
                double damage = 0;
                
                    foreach (Match number in damegData)
                    {
                    damage += double.Parse(number.Value);
                    }

                foreach (char spacialSymbol in nextName)
                {
                    if(spacialSymbol == '*')
                    {
                        damage = damage * 2;
                    }
                    else if(spacialSymbol == '/')
                    {
                        damage = damage / 2;
                    }
                }

                //Console.WriteLine(damage);

                heroes.Add(nextName, new List<double> { health, damage });

            }

            foreach (var item in heroes.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:f2} damage");
            }
        }
    }
}
