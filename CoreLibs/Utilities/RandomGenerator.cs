namespace CoreLibs.Utilities;

public class RandomGenerator
{
    private static Random _random = new Random();

    public static int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }
}