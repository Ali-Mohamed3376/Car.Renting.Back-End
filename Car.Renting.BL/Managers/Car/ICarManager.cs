using Car.Renting.BL.Dtos.Car;

namespace Car.Renting.BL;
public interface ICarManager
{
    IEnumerable<CarViewDto> GetAll();
    CarByIdDto? GetById(Guid id);
    IEnumerable<CarViewDto> CarsAfterFilteration(CarFilterationDto filter);

    IEnumerable<BrandsDto> GetAllBrands();
    IEnumerable<ModelNamesDto> GetAllModels();
    IEnumerable<ModelYearsDto> GetAllModelYears();

    bool AddCar(CarToAddDto carToAddDto);
}
