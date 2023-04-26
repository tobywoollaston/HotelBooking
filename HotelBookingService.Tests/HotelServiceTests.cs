using System.Linq.Expressions;
using CorporateHotelBooking;
using Moq;

namespace HotelBookingService.Tests;

public class HotelServiceTests
{
    [Test]
    public void GivenAHotelManager_CreateNewHotel()
    {
        const string hotelId = "HOT123";
        const string hotelName = "HotelInn";

        var expectedHotel = new Hotel()
        {
            Id = hotelId,
            Name = hotelName
        };
        var mockHotelRepository = new Mock<IHotelRepository>();

        var service = new HotelService();
        service.AddHotel(hotelId, hotelName);
        
        mockHotelRepository.Verify(x => x.Save(It.Is<Hotel>(h => h.Equals(expectedHotel))));
    }
}

public interface IHotelRepository
{
    void Save(Hotel hotel);
}