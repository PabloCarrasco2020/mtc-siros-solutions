using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseDomain<T>
    {
        Task<int> Insert(T input);
        Task<int> Update(T input);
        Task<T> Get(T input);
        Task<List<T>> GetAllByFilter(int pagina, string filter);
        Task<List<T>> GetCombo(T input);
    }
}
