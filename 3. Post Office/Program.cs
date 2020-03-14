using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _3._Post_Office
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] {'|'},StringSplitOptions.RemoveEmptyEntries);

            Regex firstLetterPattern = new Regex(@"([#$%*&])(?<firstLetter>[A-Z]+)\1");
            Regex startLetterAndLenght = new Regex(@"[0-9]{2}:[0-9]{2}");
            Regex wordtoCheck = new Regex(@"\b[A-Z][^ ]+\b");

            List<int[]> listOfWords = new List<int[]>();
            string firstLetters = firstLetterPattern.Match(input[0]).Groups["firstLetter"].Value;

            MatchCollection infoMatch = startLetterAndLenght.Matches(input[1]);
            foreach (Match item in infoMatch)
            {
                string info = item.Value;
                int[] asciiLenght = info.Split(":").Select(int.Parse).ToArray();
                listOfWords.Add(asciiLenght);
            }
            MatchCollection wordsMatch = wordtoCheck.Matches(input[2]);
            List<string> words = new List<string>();
            foreach (Match item in wordsMatch)
            {
                words.Add(item.Value);
            }
            List<string> massage = new List<string>();
            foreach (char letter in firstLetters)
            {
                bool findWord = false;
                foreach (var info in listOfWords)
                {
                    int currAsciiSymbol = info[0];
                    if (letter == currAsciiSymbol)
                    {
                        int lenght = info[1] + 1;
                        foreach (string word in words)
                        {
                            if (lenght == word.Length && word[0] == letter)
                            {
                                massage.Add(word.ToString());
                                findWord = true;
                                break;
                            }
                        }
                    }
                    if (findWord)
                    {
                        break;
                    }
                }
            }
            foreach (string word in massage)
            {
                Console.WriteLine(word);
            }
        }
    }
}
