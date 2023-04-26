using CorporateHotelBooking;
using Moq;

namespace HotelBookingService.Tests;

public class HotelLocalRepositoryTests
{
    [Test]
    public void GivenValidHotel_SaveToLocalDatabase()
    {
        var mockDatabase = new Mock<IDatabaseDriver>();
        var hotel = new Hotel()
        {
            Id = "ID",
            Name = "MyHotel1"
        };

        var repo = new HotelLocalRepository();
        repo.Save(hotel);

        string expectedHotelJsonString = "";
        mockDatabase.Verify(x => x.Save(It.Is<string>(s => s.Equals(expectedHotelJsonString))));
    }
}