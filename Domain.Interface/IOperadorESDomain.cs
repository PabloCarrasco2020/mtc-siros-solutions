using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IOperadorESDomain:IBaseDomain<TM_OPERADOR_ES>
    {
        Task<TM_OPERADOR_ES> GetXDoc(TM_OPERADOR_ES input);
    }
}
