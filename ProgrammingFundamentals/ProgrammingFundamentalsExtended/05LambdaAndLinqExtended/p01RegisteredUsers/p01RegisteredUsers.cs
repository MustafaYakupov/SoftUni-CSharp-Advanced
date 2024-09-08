using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace p01RegisteredUsers
{
    class p01RegisteredUsers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            var userData = new Dictionary<string, DateTime>();

            while (input[0] != "end")
            {
                if (userData.ContainsKey(input[0]) == false)
                {
                    userData.Add(input[0], DateTime.ParseExact(input[2], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                else
                {
                    userData[input[0]] = DateTime.ParseExact(input[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                input = Console.ReadLine().Split(' ');
            }
            var orderedDict = userData.OrderBy(x => x.Value);

            List<string> resultList = orderedDict.Select(x => x.Key).ToList();
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
