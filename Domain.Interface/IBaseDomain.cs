using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseDomain<T>
    {
        Task<T> Insert(T input);
        Task<T> Update(T input);
        Task<T> Delete(T input);
        Task<T> Get(T input);
        Task<List<T>> GetAllByFilter(int cantidadXPagina, int pagina, string filter);
        Task<List<T>> GetCombo(T input);
    }
}
