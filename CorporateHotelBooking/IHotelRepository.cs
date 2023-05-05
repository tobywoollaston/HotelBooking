namespace CorporateHotelBooking;

public interface IHotelRepository
{
    void Save(Hotel hotel);
    Hotel? GetById(string hotelId);
}