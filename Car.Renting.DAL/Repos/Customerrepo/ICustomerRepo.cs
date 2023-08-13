namespace Car.Renting.DAL;
public interface ICustomerRepo : IGenericRepo<Customer>
{
    Customer? GetCustomerByName(string name);
}
