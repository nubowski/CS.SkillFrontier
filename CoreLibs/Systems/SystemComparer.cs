namespace CoreLibs.Systems;

public class SystemComparer : IComparer<ISystem>
{
    public int Compare(ISystem? x, ISystem? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return x.Order.CompareTo(y.Order);
    }
}