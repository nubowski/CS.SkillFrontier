namespace CoreLibs;

public struct EntityId
{
    public int Id { get; }
    public int Gen { get; }

    public EntityId(int id, int gen)
    {
        Id = id;
        Gen = gen;
    }

    // TODO some equals and other override methods... here?
}