using System;
using System.Collections.Generic;
using System.Linq;

namespace p04Snowwhite
{
    class p04Snowwhite
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dwarfName = string.Empty;
            var dwarfHatColor = string.Empty;
            var dwarfPhysics = 0;

            var resultDict = new Dictionary<string, int>();
            var colors = new Dictionary<string, int>();
            
            while (input != "Once upon a time")
            {
                var dwarfs = input.Split(new char[] { '<','>', ':' },StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

                dwarfName = dwarfs[0];
                dwarfHatColor = dwarfs[1];
                dwarfPhysics = int.Parse(dwarfs[2]);
                var key = $"{dwarfName} {dwarfHatColor}";

                if (resultDict.ContainsKey(key) == false)
                {
                    resultDict.Add(key, dwarfPhysics);

                    if (colors.ContainsKey(dwarfHatColor) == false)
                    {
                        colors.Add(dwarfHatColor, 1);
                    }
                    else
                    {
                        colors[dwarfHatColor]++;
                    }
                }
                else //if(resultDict.ContainsKey($"{dwarfName}{dwarfHatColor}"))
                {
                    
                    int oldValue = resultDict[key];  //Veche zapisanite physics

                    if (dwarfPhysics > oldValue)
                    {
                        resultDict[key] = dwarfPhysics;
                    }
                    
                }
                
                input = Console.ReadLine();
            }
            Dictionary<string, int> sortedResult = resultDict
                .OrderByDescending(d => d.Value)
            .ThenByDescending(d => colors[d.Key.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]])
            .ToDictionary(x => x.Key, x => x.Value);

            foreach (var dwarf in sortedResult)
            {
                string dwarfkey = dwarf.Key;
                string[] keyParts = dwarfkey.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = keyParts[0];
                string hatColor = keyParts[1];

                int physics = dwarf.Value;

                Console.WriteLine($"({hatColor}) {name} <-> {physics}");
            }
        }
    }
}
