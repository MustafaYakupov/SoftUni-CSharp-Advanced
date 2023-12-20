namespace SpaceStation.IO
{
    using System;
    using System.IO;
    using Contracts;

    public class Writer : IWriter
    {
        //public void Write(string message)
        //{
        //    Console.Write(message);
        //}

        //public void WriteLine(string message)
        //{
        //    Console.WriteLine(message);
        //}

        string path = "../../../output.txt";

        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
