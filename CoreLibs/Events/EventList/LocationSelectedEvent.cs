using CoreLibs.Entities;

namespace CoreLibs.Events.EventList;

public class LocationSelectedEvent : IEvent
{
    public Entity SelectedLocation { get; }

    public LocationSelectedEvent(Entity selectedLocation)
    {
        SelectedLocation = selectedLocation;
    }
}