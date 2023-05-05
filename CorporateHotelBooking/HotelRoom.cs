namespace CorporateHotelBooking;

public class HotelRoom
{
    public int RoomNumber { get; init; }
    public RoomType RoomType { get; set; }

    private bool Equals(HotelRoom other)
    {
        return RoomNumber == other.RoomNumber && RoomType == other.RoomType;
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
        return HashCode.Combine(RoomNumber, (int)RoomType);
    }
}