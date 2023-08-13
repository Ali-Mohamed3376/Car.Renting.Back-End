using Car.Renting.DAL.Data;

namespace Car.Renting.DAL;

public class BookingRepo : GenericRepo<BookingCars>, IBookingRepo
{
    private readonly CarRentingContext context;

    public BookingRepo (CarRentingContext context ): base(context)
    {
        this.context = context;
    }
}
