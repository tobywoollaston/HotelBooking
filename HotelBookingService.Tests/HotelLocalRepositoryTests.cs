using CorporateHotelBooking;
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
        var hotelRepository = new HotelLocalRepository(mockDatabase.Object);

        hotelRepository.GetById(hotelId);

        mockDatabase.Verify(x => x.Get(hotelId));
    }
}