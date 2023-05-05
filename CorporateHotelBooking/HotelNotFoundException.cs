namespace CorporateHotelBooking;

public class HotelNotFoundException : Exception
{
    public HotelNotFoundException(string hotelId) : 
        base($"Hotel not found: {hotelId}")
    {
    }
}