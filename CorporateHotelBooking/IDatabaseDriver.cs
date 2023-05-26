namespace CorporateHotelBooking;

public interface IDatabaseDriver
{
    void Save(string json);
    string Get(string hotelId);
}