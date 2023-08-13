namespace Car.Renting.DAL;
public interface IGenericRepo<T> where T : class
{
    IEnumerable<T> GetAll();

    T? GetByID(Guid id);

    void Add(T entity);
}
