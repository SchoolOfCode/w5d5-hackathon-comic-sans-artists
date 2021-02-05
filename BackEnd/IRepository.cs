using System.Collections.Generic;
using System.Threading.Tasks;
public interface IRepository<T>
{
    //Task<IEnumerable<T>> GetAll();- maybe later
    // Task<IEnumerable<T>> GetByName(); - maybe later
    Task<IEnumerable<T>> GetAllByMonth(long id);
    Task<T> Insert(T item);
}