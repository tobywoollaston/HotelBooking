namespace CorporateHotelBooking;

public class Hotel
{
    public string Id { get; init; }
    public string Name { get; init; }
    public List<HotelRoom> Rooms { get; set; }
}