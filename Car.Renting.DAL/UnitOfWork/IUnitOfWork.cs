namespace Car.Renting.DAL;
public interface IUnitOfWork
{
    public ICarRepo CarRepo { get; }
    public ICustomerRepo CustomerRepo { get; }
    public IBookingRepo BookingRepo { get; }
    int Savechanges();
}
