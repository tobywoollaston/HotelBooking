namespace CorporateHotelBooking;

public interface IDatabaseDriver
{
    void Save(string json);
    Hotel Get(string hotelId);
}