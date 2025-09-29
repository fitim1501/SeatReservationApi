using CSharpFunctionalExtensions;
using Shared;

namespace SeatReservation.Domain.Venues;

public record VenueId(Guid Value);

public class Venue
{
    private List<Seat> _seats = [];
    
    //EF Core
    private Venue()
    {
        
    }

    public Venue(VenueId id, VenueName name, int seatsLimit, IEnumerable<Seat> seats)
    {
        Id = id;
        Name = name;
        this.SeatsLimit = seatsLimit;
        _seats = seats.ToList();
    }

    public VenueId Id { get; } = null!;
    
    public VenueName Name { get; private set; }
   
    public int SeatsLimit { get; private set; }
    public int SeatsCount => _seats.Count();
    
    public string Test2 { get; set; }

    public IReadOnlyList<Seat> Seats => _seats;
    
    public UnitResult<Error> AddSeat(Seat seat)
    {
        if (SeatsCount >= SeatsLimit)
        {
            return Error.Conflict("venue.seats.limit", "");
        }
        
        _seats.Add(seat);

        return UnitResult.Success<Error>();
    }
    
    public void ExpandSeatsLimit(int newSeatsLimit) => SeatsLimit = newSeatsLimit;
}