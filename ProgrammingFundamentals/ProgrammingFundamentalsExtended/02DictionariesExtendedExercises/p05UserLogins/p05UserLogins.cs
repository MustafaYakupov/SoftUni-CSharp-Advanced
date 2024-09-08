using System;
using System.Collections.Generic;
using System.Linq;

namespace p05UserLogins
{
    class p05UserLogins
    {
        static void Main(string[] args)
        {
            string[] userNamePass = Console.ReadLine().Split(' ').ToArray();
            var dict = new Dictionary<string, string>();

            string name = "";
            string password = "";
            int failsCount = 0;

            while (userNamePass[0] != "login")
            {
                name = userNamePass[0];
                password = userNamePass[2];

                if (dict.ContainsKey(name) == false)
                {
                    dict.Add(name, password);
                }
                else
                {
                    dict[name] = password;
                }
                userNamePass = Console.ReadLine().Split(' ').ToArray();
            }

            userNamePass = Console.ReadLine().Split(' ').ToArray();

            while (userNamePass[0] != "end")
            {
                foreach (var pair in dict)
                {
                    if (dict.ContainsKey(userNamePass[0]) == false)
                    {
                        Console.WriteLine($"{userNamePass[0]}: login failed");
                        failsCount++;
                        break; ;
                    }
                    else if (dict.ContainsKey(userNamePass[0]))
                    {
                        if (dict[userNamePass[0]] != userNamePass[2])
                        {
                            Console.WriteLine($"{userNamePass[0]}: login failed");
                            failsCount++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{userNamePass[0]}: logged in successfully");
                            break;
                        }
                    }
                }
                userNamePass = Console.ReadLine().Split(' ').ToArray();
            }
            
            Console.WriteLine($"unsuccessful login attempts: {failsCount}");
        }
    }
}
