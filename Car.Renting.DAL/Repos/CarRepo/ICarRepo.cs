namespace Car.Renting.DAL;
public interface ICarRepo : IGenericRepo<Car>
{
    IEnumerable<Car> GetCarsFiltered(QueryParameters queryParameters);
}
