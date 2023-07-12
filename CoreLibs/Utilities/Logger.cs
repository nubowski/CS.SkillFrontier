namespace CoreLibs.Utilities;

public class Logger
{
    public static bool DebugMode { get; set; } = false;
    
    public static void Log(string message)
    {
        Console.WriteLine(message);
    }
    
    public static void Debug(string message)
    {
        if (DebugMode)
        {
            Console.WriteLine(message);
        }
    }
}