namespace CorporateHotelBooking;

public class Hotel
{
    public string Id { get; init; }
    public string Name { get; init; }
    public List<HotelRoom> Rooms { get; set; } = new List<HotelRoom>();

    public override string ToString()
    {
        return $@"Hotel: {Id} {Name}";
    }

    public bool Equals(Hotel other)
    {
        return this.Id == other.Id && this.Name == other.Name && this.Rooms == other.Rooms;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj != null && obj.GetType() == typeof(Hotel))
        {
            return false;
        }

        return Equals((Hotel)obj!);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Rooms);
    }
}