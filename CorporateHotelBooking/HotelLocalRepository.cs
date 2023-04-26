using System.Text.Json;
using HotelBookingService.Tests;

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
}