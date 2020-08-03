using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IOperadorESRepository:IBaseRepository<TM_OPERADOR_ES>
    {
        Task<TM_OPERADOR_ES> GetXDoc(TM_OPERADOR_ES input);
    }
}
