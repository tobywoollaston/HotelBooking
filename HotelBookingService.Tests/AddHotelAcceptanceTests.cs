using CorporateHotelBooking;
using FluentAssertions;
using hotel_booking_service;
using Moq;

namespace HotelBookingService.Tests;

public class AddHotelAcceptanceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenAHotelManager_CreateAHotel()
    {
        var mockDatabaseDriver = new Mock<IDatabaseDriver>();
        var hotelService = new HotelService();
        var hotelId = "1";
        var hotelName = "The Dorchester";
        var numberOfRooms = 5;
        var doubleRoomType = RoomType.Double;
        
        hotelService.AddHotel(hotelId, hotelName);
        hotelService.SetRoom(hotelId, numberOfRooms, doubleRoomType);
        
        var expectedHotel = new Hotel()
        {
            Id = hotelId,
            Name = hotelName,
            Rooms = new List<HotelRoom>
            {
                new()
                {
                    NumberOfRooms = numberOfRooms,
                    RoomType = doubleRoomType
                }
            }

        };

        var actualHotel = hotelService.FindHotelBy(hotelId);

        actualHotel.Should().BeEquivalentTo(expectedHotel);
    }
}