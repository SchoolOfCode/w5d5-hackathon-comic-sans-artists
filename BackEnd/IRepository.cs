using System.Collections.Generic;
using System.Threading.Tasks;
public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    // Task<IEnumerable<T>> GetByName(); - maybe later
    Task<IEnumerable<T>> GetAllByMonth(string month);
    Task<T> Insert(T item);
}