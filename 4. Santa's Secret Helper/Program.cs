using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main()
        {
            int numberKey = int.Parse(Console.ReadLine());
            List<string> goodKids = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                StringBuilder temp = new StringBuilder();
                foreach (char symbol in input)
                {
                    char newSymbol = (char)(symbol - numberKey);
                    temp.Append(newSymbol);
                }
                string decriptedMassage = temp.ToString();
                Regex pattern = new Regex(@"@(?<name>[A-Za-z]+)[^\-@!:>]*!(?<behav>[GN])!");
                Match match = pattern.Match(decriptedMassage);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    char behaviour = char.Parse(match.Groups["behav"].Value);
                    if (behaviour == 'G')
                    {
                        goodKids.Add(name);
                    }
                }
            }
            foreach (string name in goodKids)
            {
                Console.WriteLine(name);
            }
        }
    }
}
