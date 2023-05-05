using HotelBookingService.Tests;

namespace CorporateHotelBooking;

public class HotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public void AddHotel(string hotelId, string hotelName)
    {
        var hotel = new Hotel
        {
            Id = hotelId,
            Name = hotelName 
        };

        _hotelRepository.Save(hotel);
    }

    public void SetRoom(string hotelId, int numberOfRooms, RoomType roomType)
    {
        
    }

    public Hotel FindHotelBy(string hotelId)
    {
        throw new NotImplementedException();
    }
}