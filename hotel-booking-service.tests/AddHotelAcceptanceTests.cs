using FluentAssertions;
using Moq;

namespace hotel_booking_service;

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

public class HotelRoom
{
    public int NumberOfRooms { get; init; }
    public RoomType RoomType { get; init; }
}

public enum RoomType
{
    Double
}

public class HotelService
{
    public void AddHotel(string hotelId, string hotelName)
    {
        throw new NotImplementedException();
    }

    public void SetRoom(string hotelId, int numberOfRooms, object roomType)
    {
        throw new NotImplementedException();
    }

    public Hotel FindHotelBy(string hotelId)
    {
        throw new NotImplementedException();
    }
}

public class Hotel
{
    public string Id { get; init; }
    public string Name { get; init; }
    public List<HotelRoom> Rooms { get; set; }
}

public class IDatabaseDriver
{
    public void Save(object hotel)
    {
        throw new NotImplementedException();
    }
}