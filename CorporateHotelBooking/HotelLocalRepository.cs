using System.Text.Json;

namespace CorporateHotelBooking;

public class HotelLocalRepository : IHotelRepository
{
    private readonly IDatabaseDriver _localDatabase;

    public HotelLocalRepository(IDatabaseDriver localDatabase)
    {
        _localDatabase = localDatabase;
    }

    public void Save(Hotel hotel)
    {
        var hotelJsonString = JsonSerializer.Serialize(hotel);
        
        _localDatabase.Save(hotelJsonString);
    }

    public Hotel? GetById(string hotelId)
    {
        var hotelJson = _localDatabase.Get(hotelId);
        try
        {
            var hotel = JsonSerializer.Deserialize<Hotel>(hotelJson);
            return hotel;
        }
        catch
        {
            return null;
        }
    }
}