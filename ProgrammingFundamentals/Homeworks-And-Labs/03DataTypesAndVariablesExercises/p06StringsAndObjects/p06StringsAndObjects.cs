using System;

namespace p06StringsAndObjects
{
    class p06StringsAndObjects
    {
        static void Main(string[] args)
        {
            string first = "Hello";
            string second = "World";
            object third = first + " " + second;
            string final = (string)third;
            Console.WriteLine(final);
        }
    }
}
