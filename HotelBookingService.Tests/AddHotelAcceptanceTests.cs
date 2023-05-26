using System.Text.Json;
using System.Text.Json.Serialization;
using CorporateHotelBooking;
using FluentAssertions;
using Moq;

namespace HotelBookingService.Tests
{
    public class AddHotelAcceptanceTests
    {
        private const string HotelId = "1";
        private const string HotelName = "The Dorchester";
        private const int RoomNumber = 5;
        private const RoomType DoubleRoomType = RoomType.Double;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAHotelManager_CreateAHotel()
        {
            var mockDatabaseDriver = new Mock<IDatabaseDriver>();
            var hotelDatabaseDriverInstance = new Hotel()
            {
                Id = HotelId,
                Name = HotelName,
            };

            mockDatabaseDriver.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(JsonSerializer.Serialize(hotelDatabaseDriverInstance));

            var hotelRepository = new HotelLocalRepository(mockDatabaseDriver.Object);
            var hotelService = new HotelService(hotelRepository);

            hotelService.AddHotel(HotelId, HotelName);
            hotelService.SetRoom(HotelId, RoomNumber, DoubleRoomType);

            var expectedHotel = new Hotel()
            {
                Id = HotelId,
                Name = HotelName,
                Rooms = new List<HotelRoom>
                {
                    new()
                    {
                        RoomNumber = RoomNumber,
                        RoomType = DoubleRoomType
                    }
                }
            };

            var actualHotel = hotelService.FindHotelBy(HotelId);

            actualHotel.Should().BeEquivalentTo(expectedHotel);
        }
    }
}