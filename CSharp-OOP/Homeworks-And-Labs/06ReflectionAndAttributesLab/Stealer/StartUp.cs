namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();

            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            string result = spy.CollectGettersAndSetters(typeof(Hacker).FullName);

            Console.WriteLine(result);
        }
    }
}


