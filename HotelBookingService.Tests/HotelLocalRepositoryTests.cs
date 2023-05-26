using CorporateHotelBooking;
using FluentAssertions;
using Moq;

namespace HotelBookingService.Tests;

public class HotelLocalRepositoryTests
{
    [Test]
    public void GivenValidHotel_SaveToLocalDatabase()
    {
        var hotel = new Hotel()
        {
            Id = "ID",
            Name = "MyHotel1"
        };

        var mockDatabase = new Mock<IDatabaseDriver>();
        var repo = new HotelLocalRepository(mockDatabase.Object);
        
        repo.Save(hotel);

        string expectedHotelJsonString = "{\"Id\":\"ID\",\"Name\":\"MyHotel1\",\"Rooms\":[]}";
        mockDatabase.Verify(x => x.Save(It.Is<string>(s => s.Equals(expectedHotelJsonString))));
    }

    [Test]
    public void GivenAValidId_ReturnHotel()
    {
        var hotelId = "hotelId";
        var mockDatabase = new Mock<IDatabaseDriver>();
        string hotelString = $"{{\"Id\":\"{hotelId}\",\"Name\":\"MyHotel1\",\"Rooms\":[]}}";
        mockDatabase.Setup(x => x.Get(It.IsAny<string>())).Returns(hotelString);
        var hotelRepository = new HotelLocalRepository(mockDatabase.Object);

        var hotel = hotelRepository.GetById(hotelId);

        mockDatabase.Verify(x => x.Get(hotelId));
        hotel.Should().BeEquivalentTo(new Hotel()
        {
            Id = hotelId,
            Name = "MyHotel1"
        });
    }

    [Test]
    public void GivenHotelNotFound_ReturnNull()
    {
        var mockDatabase = new Mock<IDatabaseDriver>();
        mockDatabase.Setup(x => x.Get(It.IsAny<string>())).Returns((string)null!);
        var hotelRepository = new HotelLocalRepository(mockDatabase.Object);

        var hotel = hotelRepository.GetById("hotelId");

        hotel.Should().Be(null);
    }
    
    [Test]
    public void GivenInvalidJson_ReturnNull()
    {
        var mockDatabase = new Mock<IDatabaseDriver>();
        mockDatabase.Setup(x => x.Get(It.IsAny<string>())).Returns("");
        var hotelRepository = new HotelLocalRepository(mockDatabase.Object);

        var hotel = hotelRepository.GetById("hotelId");

        hotel.Should().Be(null);
    }
}