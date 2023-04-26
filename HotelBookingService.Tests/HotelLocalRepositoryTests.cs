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

        string expectedHotelJsonString = "{\"Id\": \"ID\", \"Name\": \"MyHotel1\" }";
        mockDatabase.Verify(x => x.Save(It.Is<string>(s => s.Equals(expectedHotelJsonString))));
    }
}