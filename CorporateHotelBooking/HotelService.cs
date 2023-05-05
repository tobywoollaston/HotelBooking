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

    public void SetRoom(string hotelId, int roomNumber, RoomType roomType)
    {
        var hotel = _hotelRepository.GetById(hotelId);
        if (hotel is null)
        {
            throw new HotelNotFoundException(hotelId);
        }
        
        hotel.Rooms.Add(new HotelRoom()
        {
            RoomType = roomType,
            RoomNumber = roomNumber
        });
        
        _hotelRepository.Save(hotel);
    }

    public Hotel FindHotelBy(string hotelId)
    {
        throw new NotImplementedException();
    }
}