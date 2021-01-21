using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Task04_Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@([A-za-z]+)\d*[^@\-!:>]*:(\d+)[^@\-!:>]*!([AD])![^@\-!:>]*->(\d+)";

            List<string> atakedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            Regex extractInfo = new Regex(pattern);

            int numberMesages = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberMesages; i++)
            {
                string codeMesage = Console.ReadLine();

                int starCode = 0;

                foreach (char letter in codeMesage)
                {
                    if(letter.ToString().ToUpper() == "S" ||
                        letter.ToString().ToUpper() == "T" ||
                        letter.ToString().ToUpper() == "A" ||
                        letter.ToString().ToUpper() == "R")
                    {
                        starCode++;
                    }
                }

                //Console.WriteLine(starCode);

                string decodeMesage = string.Empty;

                foreach (char letter in codeMesage)
                {
                    int asciiCode = letter;
                    asciiCode -= starCode;
                    decodeMesage += (char)asciiCode; 
                }

                //Console.WriteLine(decodeMesage);

                Match validInfo = extractInfo.Match(decodeMesage);

                if(validInfo.Success)
                {
                    string planet = validInfo.Groups[1].Value;
                    string typeAction = validInfo.Groups[3].Value;

                    if(typeAction == "A")
                    {
                        atakedPlanets.Add(planet);
                    }
                    else
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {atakedPlanets.Count}");
            
            foreach (string planet in atakedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (string planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

        }
    }
}
