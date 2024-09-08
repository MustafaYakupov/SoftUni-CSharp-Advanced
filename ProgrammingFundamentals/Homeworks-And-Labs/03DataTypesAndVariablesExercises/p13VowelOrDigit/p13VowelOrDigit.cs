using System;

namespace p13VowelOrDigit
{
    class p13VowelOrDigit
    {
        static void Main(string[] args)
        {
            char input;
            input = Convert.ToChar(Console.ReadLine());
            if (input >= 'a' && input <= 'z')
            {
                Console.WriteLine("vowel");
            }
            else if (input >= '0' && input <= '9')
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
               
           
            
        }
    }
}
