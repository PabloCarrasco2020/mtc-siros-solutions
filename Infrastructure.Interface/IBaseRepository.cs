using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IBaseRepository<T>
    {
        Task<int> Insert(T input);
        Task<int> Update(T input);
        Task<T> Get(T input);
        Task<List<T>> GetAllByFilter(int pagina, string filter);
        Task<List<T>> GetCombo(T input);
    }
}
