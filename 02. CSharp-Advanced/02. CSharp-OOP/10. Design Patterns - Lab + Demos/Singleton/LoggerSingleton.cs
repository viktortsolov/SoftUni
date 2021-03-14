public sealed class LoggerSingleton
{
    private static LoggerSingleton instance;
    private static object someLock = new object();

    private LoggerSingleton() { }

    public void LogToFile()
    {
        System.Console.WriteLine("Logged to file");
    }

    public static LoggerSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock(someLock)
                {
                    if (instance == null)
                    {
                        System.Console.WriteLine("Created instance only once!");
                        instance = new LoggerSingleton();
                    }
                }
            }
            return instance;
        }
    }
}
