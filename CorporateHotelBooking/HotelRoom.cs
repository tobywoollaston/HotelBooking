namespace CorporateHotelBooking;

public class HotelRoom
{
    public int NumberOfRooms { get; init; }
    public RoomType RoomType { get; init; }

    private bool Equals(HotelRoom other)
    {
        return NumberOfRooms == other.NumberOfRooms && RoomType == other.RoomType;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((HotelRoom)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NumberOfRooms, (int)RoomType);
    }
}