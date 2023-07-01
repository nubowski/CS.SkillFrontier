namespace CoreLibs.Utilities;

public class IdGenerator
{
    public static Guid NewId()
    {
        return Guid.NewGuid();
    }
}

