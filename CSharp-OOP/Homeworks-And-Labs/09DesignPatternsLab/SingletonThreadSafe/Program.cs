
for (int i = 0; i < 100; i++)
{
    new Thread(() =>
    {
        LoggedUserSingleton.Instance.Name = i.ToString();
    }).Start();
}

Console.WriteLine("Who are you?");
string name = Console.ReadLine();

LoggedUserSingleton.Instance.Name = name;

Console.WriteLine($"{LoggedUserSingleton.Instance.Name} is logged in");

class LoggedUserSingleton
{
    private static LoggedUserSingleton instance;
    private static object lockObject = new object();
    private LoggedUserSingleton()
    {
        Console.WriteLine("Logged user created");
    }
    public string Name { get; set; }

    public static LoggedUserSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new LoggedUserSingleton();
                    }
                }
            }
            return instance;
        }
    }
}