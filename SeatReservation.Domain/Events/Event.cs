using SeatReservation.Domain.Venues;

namespace SeatReservation.Domain.Events;

public record EventId(Guid Value);

public class Event
{
    public Event()
    {
        
    }
    public Event(EventId id, VenueId venueId, string name, DateTime eventDate, EventDetails details)
    {
        Id = id;
        VenueId = venueId;
        Name = name;
        EventDate = eventDate;
        Details = details;
    }
    public EventId Id { get; } 
    
    public EventDetails Details { get; private set; }
    public VenueId VenueId { get; private set; }
    
    public string Name { get; private set; }
    public DateTime EventDate { get; private set; }
    
    
}