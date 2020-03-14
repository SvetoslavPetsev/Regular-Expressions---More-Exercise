using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<char> uniqueSimbols = new List<char>();

            List<string> letters = new List<string>();
            List<int> numbers = new List<int>();
            Regex patternLetters = new Regex(@"[^\d]+");
            Regex patternNumbers = new Regex(@"[\d]{1,2}");

            MatchCollection machText = patternLetters.Matches(input);
            foreach(Match part in machText)
            {
                string text = part.Value;
                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    char currSymbol = text[i];
                    if (Char.IsLetter(currSymbol))
                    {
                        char up = Char.ToUpper(currSymbol);
                        currSymbol = up;
                    }
                    temp.Append(currSymbol);
                }
                letters.Add(temp.ToString()); 
            }
            MatchCollection machNumbers = patternNumbers.Matches(input);
            foreach (Match number in machNumbers)
            {
                int num = int.Parse(number.Value);
                numbers.Add(num);
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < letters.Count; i++)
            {
                for (int j = 0; j < numbers[i]; j++)
                {
                    result.Append(letters[i]);
                }
            }
            foreach (char symbol in result.ToString())
            {
                if (!uniqueSimbols.Contains(symbol))
                {
                    uniqueSimbols.Add(symbol);
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSimbols.Count}");
            Console.WriteLine(result.ToString());
        }
    }
}
