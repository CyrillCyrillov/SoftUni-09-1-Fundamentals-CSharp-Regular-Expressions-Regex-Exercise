using System;
using System.Text.RegularExpressions;

namespace Task06_Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?<=\s)[a-zA-Z0-9]+([-.]\w*)*@[a-zA-Z]+?([.-][a-zA-Z]*)*(\.[a-z]{2,}))";  // [A-z0-9-_\.]+@[A-z]+.[A-z]+\.[A-z]+

            Regex emailExtract = new Regex(pattern);

            string text = Console.ReadLine();

            MatchCollection allEmails = emailExtract.Matches(text);

            foreach (Match item in allEmails)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
