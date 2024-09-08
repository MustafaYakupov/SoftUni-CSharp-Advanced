using System;
using System.Collections.Generic;
using System.Linq;

namespace p04RoliTheCoder
{
    class p04RoliTheCoder
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var eventDict = new Dictionary<int, string>();
            var participantsDict = new Dictionary<int, List<string>>();


            while (input != "Time for Code")
            {
                var events = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var id = int.Parse(events[0]);
                var eventName = events[1];
                var participants = new List<string>();

                foreach (var person in participants)
                {
                    var isValid = person
                        .Where(s => char.IsLetterOrDigit(s)
                        && s == '\'' && s == '-');
                }

                foreach (var element in events)
                {
                    if (element.Contains("@"))
                    {
                        participants.Add(element);
                    }
                }

                if (eventName.Contains("#") == false)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (eventDict.ContainsKey(id) == false)
                {
                    eventDict.Add(id, eventName);
                    participantsDict[id] = participants;
                }
                else if (eventDict.ContainsKey(id))
                {
                    var existingEventName = eventDict[id];

                    if (existingEventName == eventName)
                    {

                        participantsDict[id].AddRange(participants);
                    }
                    else
                    {
                        input = Console.ReadLine();

                        continue;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in participantsDict.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                var id = kvp.Key;
                var currEvent = kvp.Value;
                var count = participantsDict[id].Distinct().Count();
                string eventT = eventDict[id].Trim('#');      //Substring(1);
                Console.WriteLine($"{eventT} - {count}");

                foreach (var people in kvp.Value.Distinct().OrderBy(x => x))
                {

                    Console.WriteLine($"{people}");
                }

            }
        }
    }
}
