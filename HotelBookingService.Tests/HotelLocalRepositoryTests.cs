using CorporateHotelBooking;
using FluentAssertions;
using Moq;

namespace HotelBookingService.Tests;

public class HotelLocalRepositoryTests
{
    private Mock<IDatabaseDriver> _mockDatabase = null!;
    private HotelLocalRepository _hotelLocalRepository = null!;

    [SetUp]
    public void SetUp()
    {
        _mockDatabase = new Mock<IDatabaseDriver>();
        _hotelLocalRepository = new HotelLocalRepository(_mockDatabase.Object);
    }
    
    [Test]
    public void GivenValidHotel_SaveToLocalDatabase()
    {
        var hotel = new Hotel()
        {
            Id = "ID",
            Name = "MyHotel1"
        };

        _hotelLocalRepository.Save(hotel);

        string expectedHotelJsonString = "{\"Id\":\"ID\",\"Name\":\"MyHotel1\",\"Rooms\":[]}";
        _mockDatabase.Verify(x => x.Save(It.Is<string>(s => s.Equals(expectedHotelJsonString))));
    }

    [Test]
    public void GivenAValidId_ReturnHotel()
    {
        var hotelId = "hotelId";
        string hotelString = $"{{\"Id\":\"{hotelId}\",\"Name\":\"MyHotel1\",\"Rooms\":[]}}";
        _mockDatabase.Setup(x => x.Get(It.IsAny<string>())).Returns(hotelString);

        var hotel = _hotelLocalRepository.GetById(hotelId);

        _mockDatabase.Verify(x => x.Get(hotelId));
        hotel.Should().BeEquivalentTo(new Hotel()
        {
            Id = hotelId,
            Name = "MyHotel1"
        });
    }

    [Test]
    public void GivenHotelNotFound_ReturnNull()
    {
        _mockDatabase.Setup(x => x.Get(It.IsAny<string>())).Returns((string)null!);

        var hotel = _hotelLocalRepository.GetById("hotelId");

        hotel.Should().Be(null);
    }

    [Test]
    public void GivenInvalidJson_ReturnNull()
    {
        _mockDatabase.Setup(x => x.Get(It.IsAny<string>())).Returns("");

        var hotel = _hotelLocalRepository.GetById("hotelId");

        hotel.Should().Be(null);
    }
}