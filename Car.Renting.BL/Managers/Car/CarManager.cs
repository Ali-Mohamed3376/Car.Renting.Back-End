using Car.Renting.BL.Dtos.Car;
using Car.Renting.DAL;

namespace Car.Renting.BL;
public class CarManager : ICarManager
{
    private readonly IUnitOfWork unitOfWork;

    public CarManager(IUnitOfWork _unitOfWork)
    {
        this.unitOfWork = _unitOfWork;
    }

    public IEnumerable<CarViewDto> GetAll()
    {
        var carsFromDB = unitOfWork.CarRepo.GetAll();
        var carDto = carsFromDB.Select(c => new CarViewDto
        {
            Id = c.Id,
            ModelName = c.ModelName,
            BrandName = c.BrandName,
            ModelType = c.ModelType,
            ModelYear = c.ModelYear,
            Power = c.Power,
            Counter = c.Counter
        });

        return carDto;
    }

    public CarByIdDto? GetById(Guid id)
    {
        var carFromDb = unitOfWork.CarRepo.GetByID(id);
        CarByIdDto car = new CarByIdDto
        {
            Id = carFromDb.Id,
            BrandName = carFromDb.BrandName,
            ModelName = carFromDb.ModelName,
            ModelType = carFromDb.ModelType,
            ModelYear = carFromDb.ModelYear,
            Power = carFromDb.Power,
            Counter = carFromDb.Counter
        };
        return car; 
    }

    public IEnumerable<CarViewDto> CarsAfterFilteration(CarFilterationDto filter)
    {
        var queruyParameters = new QueryParameters
        {
            BrandName = filter.BrandName,
            ModelName = filter.ModelName,
            ModelYear = filter.ModelYear
        };

        var carFiltersedFromDB = unitOfWork.CarRepo.GetCarsFiltered(queruyParameters);

        IEnumerable<CarViewDto> carViewDtos = carFiltersedFromDB.Select(c => new CarViewDto
        {
            Id = c.Id,
            BrandName = c.BrandName,
            ModelName = c.ModelName,
            ModelType = c.ModelType,
            ModelYear = c.ModelYear,
            Power = c.Power,
            Counter = c.Counter
        });
        return carViewDtos;
    }

    public IEnumerable<BrandsDto> GetAllBrands()
    {
        var carsWithBrandsFromDB = unitOfWork.CarRepo.GetAll()
                                                     .Select(c => c.BrandName)
                                                     .Distinct();
        IEnumerable<BrandsDto> brandsDto = carsWithBrandsFromDB.Select(c => new BrandsDto
        {
            Brand = c,
        });

        return brandsDto;
    }

    public IEnumerable<ModelNamesDto> GetAllModels()
    {
        var carsWithModelsFromDB = unitOfWork.CarRepo.GetAll()
                                                      .Select(c => new { c.ModelName, c.Id })
                                                      .Distinct();
        IEnumerable<ModelNamesDto> modelssDto = carsWithModelsFromDB.Select(c => new ModelNamesDto
        {
            Name = c.ModelName,
            CarId = c.Id
        });

        return modelssDto;
    }

    public IEnumerable<ModelYearsDto> GetAllModelYears()
    {
        var carsWithModelYearsFromDB = unitOfWork.CarRepo.GetAll().Select(c => c.ModelYear).Distinct();
        IEnumerable<ModelYearsDto> modelYearsDto = carsWithModelYearsFromDB.Select(c => new ModelYearsDto
        {
            ModelYears = c,
        });

        return modelYearsDto;
    }

    public bool AddCar(CarToAddDto carToAddDto)
    {
        var car = new Car.Renting.DAL.Car
        {
            Id = Guid.NewGuid(),
            ModelName = carToAddDto.ModelName,
            ModelType = carToAddDto.ModelType,
            ModelYear = carToAddDto.ModelYear,
            BrandName = carToAddDto.BrandName,
            Power = carToAddDto.Power
        };

        unitOfWork.CarRepo.Add(car);
        return unitOfWork.Savechanges() > 0 ? true : false;
    }
}
