using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Beast!")
                {
                    return;
                }

                string[] details = Console.ReadLine().Split(" ").ToArray();

                string name = details[0];
                int age = int.Parse(details[1]);
                string gender = details[2];

                try
                {
                    if (input == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                    }
                    else if (input == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                    }
                    else if (input == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age, gender);
                        Console.WriteLine(kitten);
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age, gender);
                        Console.WriteLine(tomcat);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
