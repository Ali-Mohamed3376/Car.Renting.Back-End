namespace Car.Renting.DAL;
public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
{
    private readonly CarRentingContext context;

    public CustomerRepo(CarRentingContext context) : base(context)
    {
        this.context = context;
    }

    public Customer? GetCustomerByName(string name)
    {
        return context.Customers.Where( c => c.Name == name).FirstOrDefault();
    }
}
