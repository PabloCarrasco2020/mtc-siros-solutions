using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IEstacionServicioDomain:IBaseDomain<TM_ESTACIONSERVICIO>
    {
        Task<List<TM_ESTACIONSERVICIO>> GetComboEstXEnt(TM_ESTACIONSERVICIO input);
    }
}
