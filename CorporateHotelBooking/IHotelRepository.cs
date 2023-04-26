using CorporateHotelBooking;

namespace HotelBookingService.Tests;

public interface IHotelRepository
{
    void Save(Hotel hotel);
}