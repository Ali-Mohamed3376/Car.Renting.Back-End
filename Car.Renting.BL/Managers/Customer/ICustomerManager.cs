namespace Car.Renting.BL;
public interface ICustomerManager
{
    bool Add(CustomerToAddDto customerToAdd);

    CustomerToViewDto? GetUserByName(CustomerNameDto name);
}
