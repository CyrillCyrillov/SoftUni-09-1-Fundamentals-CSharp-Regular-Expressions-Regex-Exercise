using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Task02_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string paternName = @"[a-zA-Z]";
            string patternDistance = @"\d";

            Regex findName = new Regex(paternName);
            Regex findDistance = new Regex(patternDistance);

            Dictionary<string, int> participants = new Dictionary<string, int>();

            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string item in names)
            {
                if(!participants.ContainsKey(item))
                {
                    participants.Add(item, 0);
                }
            }

            while (true)
            {
                string dataLine = Console.ReadLine();

                if(dataLine.ToUpper() == "END OF RACE")
                {
                    break;
                }

                MatchCollection charsName = findName.Matches(dataLine);
                
                string nextName = string.Empty;
                foreach (var element in charsName)
                {
                    nextName += element;
                }

                if(participants.ContainsKey(nextName))
                {
                    MatchCollection digitsDistance = findDistance.Matches(dataLine);

                    int nextDistance = 0;
                    foreach (var element in digitsDistance)
                    {
                        nextDistance += int.Parse(element.ToString());
                    }

                    participants[nextName] = participants[nextName] + nextDistance;
                }
            }

            int count = 1;

            foreach (var item in participants.OrderByDescending(x => x.Value))
            {
                string sufix = count == 1 ? "st" : count == 2 ? "nd" : "rd";
                
                Console.WriteLine($"{count}{sufix} place: {item.Key}");
                
                count++;

                if (count == 4) break;
            }
        }
    }
}
