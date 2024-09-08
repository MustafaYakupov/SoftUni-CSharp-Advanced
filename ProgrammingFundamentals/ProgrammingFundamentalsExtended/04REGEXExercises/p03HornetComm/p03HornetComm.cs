using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p03HornetComm
{
    class p03HornetComm
    {
        static void Main(string[] args)
        {
            string privatePattern = @"^([0-9]+) <-> ([A-Za-z0-9]+)$";
            string broadcastPattern = @"^([^0-9]+) <-> ([A-Za-z0-9]+)$";

            var privateList = new List<string>();
            var broadcastList = new List<string>();

            string input = Console.ReadLine();
            

            while (input != "Hornet is Green")
            {
                string[] message = input.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (Regex.IsMatch(input, privatePattern))
                {
                    char[] word = message[0].ToCharArray();
                    Array.Reverse(word);
                    string code = "";
                    foreach (var letter in word)
                    {
                        code += letter;
                    }
                    string theMessage = message[1];

                    privateList.Add($"{code} ->{theMessage}");
                }
                else if (Regex.IsMatch(input, broadcastPattern))
                {
                    string theMessage = message[0];
                    string frequency = message[1];
                    frequency = UpdateLetters(message[1]);

                    broadcastList.Add($"{frequency} -> {theMessage}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcastList.Count > 0)
            {
                foreach (var item in broadcastList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (privateList.Count > 0)
            {
                foreach (var s in privateList)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        private static string UpdateLetters(string frequency)
        {
            string result = "";

            foreach (var symbol in frequency)
            {
                if (char.IsUpper(symbol))
                {
                    result += char.ToLower(symbol);
                }
                else if (char.IsLower(symbol))
                {
                    result += char.ToUpper(symbol);
                }
                else
                {
                    result += symbol;
                }
            }
            return result;
        }
    }
}
