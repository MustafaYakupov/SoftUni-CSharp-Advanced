using System;
using System.Text;

namespace p03UnicodeCaharacters
{
    class p03UnicodeCaharacters
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
           
                StringBuilder stringBuilder = new StringBuilder();
                foreach (char symbol in word)
                {
                    stringBuilder.Append("\\u");
                    stringBuilder.Append(String.Format("{0:x4}", (int)symbol));
                }
                string result = stringBuilder.ToString();
            Console.WriteLine(result);
        }

    }
}
