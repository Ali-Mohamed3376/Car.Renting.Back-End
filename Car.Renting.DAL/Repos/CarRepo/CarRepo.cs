using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Car.Renting.DAL;
public class CarRepo : GenericRepo<Car>, ICarRepo
{
    private readonly CarRentingContext context;

    public CarRepo(CarRentingContext context ): base(context)
    {
        this.context = context;
    }

    public IEnumerable<Car> GetAllCarsWithCustomers()
    {
        return this.context.Set<Car>().AsNoTracking();
                         
    }

    public IEnumerable<Car> GetCarsFiltered(QueryParameters queryParameters)
    {
        var cars = context.Cars.AsQueryable();

        if (queryParameters.ModelName != null || queryParameters.ModelName!= "")
        {
            cars = cars.Where(q => q.ModelName.Contains(queryParameters.ModelName));
        }

        if (queryParameters.BrandName != null || queryParameters.BrandName != "")
        {
            cars = cars.Where(q => q.BrandName.Contains(queryParameters.BrandName));
        }

        if (queryParameters.ModelYear > 0)
        {
            cars = cars.Where(q => q.ModelYear == queryParameters.ModelYear);
        }

        return cars;
    }
}
