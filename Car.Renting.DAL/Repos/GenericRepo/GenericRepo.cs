using Microsoft.EntityFrameworkCore;

namespace Car.Renting.DAL;
public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly CarRentingContext context;

    public GenericRepo(CarRentingContext context)
    {
        this.context = context;
    }

  
    public IEnumerable<T> GetAll()
    {
        return context.Set<T>().AsNoTracking();
    }

    public T? GetByID(Guid id)
    {
        return context.Set<T>()
                      .Find(id);
    }

    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

}
