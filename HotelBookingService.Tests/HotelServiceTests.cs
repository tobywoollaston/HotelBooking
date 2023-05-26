using CorporateHotelBooking;
using FluentAssertions;
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
        const string hotelId = "HOT123";

        var mockHotelRepository = new Mock<IHotelRepository>();
        mockHotelRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns((Hotel)null!);
        var service = new HotelService(mockHotelRepository.Object);

        var exception = Assert.Throws<HotelNotFoundException>(() => service.SetRoom(hotelId, 5, RoomType.Double));
        exception!.Message.Should().Contain(hotelId);
    }

    [Test]
    public void GivenAHotelAlreadyHasARoom_OverrideRoomType()
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
            Name = hotelName,
            Rooms = new List<HotelRoom>()
            {
                new()
                {
                    RoomNumber = 5,
                    RoomType = RoomType.Single
                }
            }
        };

        mockHotelRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(returnedHotel);
        var service = new HotelService(mockHotelRepository.Object);

        service.SetRoom(hotelId, 5, RoomType.Double);

        mockHotelRepository.Verify(x =>
            x.Save(It.Is<Hotel>(h => h.Equals(expectedHotel))));
    }


    [Test]
    public void GivenAHotelIsSuccessfullyFound_ReturnHotel()
    {
        var mockHotelRepository = new Mock<IHotelRepository>();
        var hotelService = new HotelService(mockHotelRepository.Object);

        var hotelId = "hotelId";
        hotelService.FindHotelBy(hotelId);

        mockHotelRepository.Verify(x => x.GetById(hotelId));
    }
    
    
    //next to throw not found exception and return hotel
}