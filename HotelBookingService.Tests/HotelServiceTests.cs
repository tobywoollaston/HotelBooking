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
        var service = new HotelService(mockHotelRepository.Object);
        
        service.AddHotel(hotelId, hotelName);

        mockHotelRepository.Verify(x => 
            x.Save(It.Is<Hotel>(h => h.Equals(expectedHotel))));
    }

    [Test]
    public void GivenAHotelManager_SetARoomToAHotel()
    {
        const string hotelId = "HOT123";
        const string hotelName = "HotelInn";

        var expectedHotel = new Hotel()
        {
            Id = hotelId,
            Name = hotelName,
            Rooms = new List<HotelRoom>()
            {
                new()
                {
                    RoomNumber = 5,
                    RoomType = RoomType.Double
                }
            }
        };
        
        var mockHotelRepository = new Mock<IHotelRepository>();
        var returnedHotel = new Hotel()
        {
            Id = hotelId,
            Name = hotelName
        };
        
        mockHotelRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(returnedHotel);
        var service = new HotelService(mockHotelRepository.Object);
        
        service.SetRoom(hotelId, 5, RoomType.Double);
        
        mockHotelRepository.Verify(x =>
            x.Save(It.Is<Hotel>(h => h.Equals(expectedHotel))));
    }

    [Test]
    public void GivenAHotelDoesNotExistWhenSettingARoom_ThrowNoHotelFoundException()
    {
        
    }
}