namespace CoreLibs.Components;

public class ComponentFilter
{
    public List<Type> MustHaveComponents { get; set; } = new List<Type>();
    public List<Type> MustNotHaveComponents { get; set; } = new List<Type>();
    public List<Type> MayHaveComponents { get; set; } = new List<Type>();
}