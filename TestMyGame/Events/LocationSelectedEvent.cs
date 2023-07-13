using CoreLibs.Core;
using CoreLibs.Events;

namespace TestMyGame.Events;

public class LocationSelectedEvent : IEvent
{
    public Entity SelectedLocation { get; }

    public LocationSelectedEvent(Entity selectedLocation)
    {
        SelectedLocation = selectedLocation;
    }
}