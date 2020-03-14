using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main()
        {
            List<string[]> listTickets = new List<string[]>();
            string input = Console.ReadLine();
            string[] tickets = input.Split(new char[] {' ', ','},StringSplitOptions.RemoveEmptyEntries);
            Regex winPattern = new Regex(@"([\@]{6,10}|[\#]{6,10}|[\$]{6,10}|[\^]{6,10})");
            foreach (var item in tickets)
            {        
                if (item.Length == 20)
                {
                    string leftPart = item.Substring(0, 10);
                    string rightPart = item.Substring(10);
                    Match left = winPattern.Match(leftPart);
                    Match right = winPattern.Match(rightPart);

                    if (!left.Success || !right.Success)
                    {
                        listTickets.Add(new string[] { item, "no match" });
                        continue;
                    }
                    else
                    {
                        string leftElements = left.ToString();
                        string rightElements = right.ToString();

                        if (leftElements[0] != rightElements[0])
                        {
                            listTickets.Add(new string[] { item, "no match" });
                            continue;
                        }
                        else
                        {
                            int leftProfit = leftElements.Length;
                            int rightProfit = rightElements.Length;

                            int profitMin = leftProfit;
                            if (leftProfit > rightProfit)
                            {
                                profitMin = rightProfit;
                            }

                            string profit = profitMin.ToString() + leftElements[0];
                            if (profitMin == 10)
                            {
                                listTickets.Add(new string[] { item, $"{profit} Jackpot!" });
                            }
                            else
                            {
                                listTickets.Add(new string[] { item, profit });
                            }
                        }
                    }
                }
                else
                {
                    listTickets.Add(new string[] { "invalid ticket", ""});
                }
            }
            foreach (string[] ticket in listTickets)
            {
                if (ticket[0] == "invalid ticket")
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket[0]}\" - {ticket[1]}  ");
                }
            }
        }
    }
}
