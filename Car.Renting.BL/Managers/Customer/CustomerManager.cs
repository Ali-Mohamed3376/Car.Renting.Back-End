using Car.Renting.DAL;

namespace Car.Renting.BL;
public class CustomerManager : ICustomerManager
{
    private readonly IUnitOfWork unitOfWork;

    public CustomerManager(IUnitOfWork _unitOfWork)
    {
        this.unitOfWork = _unitOfWork;
    }

    public bool Add(CustomerToAddDto customerToAdd)
    {
        var customer = new Customer
        {
            Name = customerToAdd.Name,
            Nationality = customerToAdd.Nationality,
            AdvancedPayment = customerToAdd.AdvancedPayment,
            DrivingLicenseNo = customerToAdd.DrivingLicenseNo,
        };

        unitOfWork.CustomerRepo.Add(customer);
        return unitOfWork.Savechanges() > 0 ? true : false;

    }

    public CustomerToViewDto? GetUserByName(CustomerNameDto name)
    {
        var customerFromDB = unitOfWork.CustomerRepo.GetCustomerByName(name.Name);
        if (customerFromDB is null)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = name.Name,
                Nationality = name.Nationality,
                AdvancedPayment = name.AdvancedPayment,
                DrivingLicenseNo = name.DrivingLicenseNo,
            };
            unitOfWork.CustomerRepo.Add(customer);
            unitOfWork.Savechanges();

            CustomerToViewDto dto = new CustomerToViewDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Nationality = customer.Nationality,
                DrivingLicenseNo = customer.DrivingLicenseNo,
                AdvancedPayment = customer.AdvancedPayment,
            };
            return dto;
        }
        else
        {

            CustomerToViewDto dto = new CustomerToViewDto
            {
                Id = customerFromDB.Id,
                Name = customerFromDB.Name,
                Nationality = customerFromDB.Nationality,
                DrivingLicenseNo = customerFromDB.DrivingLicenseNo,
                AdvancedPayment = customerFromDB.AdvancedPayment,
            };
            return dto;
        }
    }
}
