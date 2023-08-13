namespace Car.Renting.DAL;
public class UnitOfWork : IUnitOfWork
{
    private readonly CarRentingContext context;

    public ICarRepo CarRepo { get; }

    public ICustomerRepo CustomerRepo { get; }

    public IBookingRepo BookingRepo { get; }

    public UnitOfWork(CarRentingContext context, ICarRepo carRepo, ICustomerRepo customerRepo, IBookingRepo bookingRepo)
    {
        this.context = context;
        CarRepo = carRepo;
        CustomerRepo = customerRepo;
        BookingRepo = bookingRepo;
    }


    public int Savechanges()
    {
        return context.SaveChanges();
    }
}
