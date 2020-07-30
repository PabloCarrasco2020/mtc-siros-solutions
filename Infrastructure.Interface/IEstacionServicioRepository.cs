using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IEstacionServicioRepository:IBaseRepository<TM_ESTACIONSERVICIO>
    {
        Task<List<TM_ESTACIONSERVICIO>> GetComboEstXEnt(TM_ESTACIONSERVICIO input);
    }
}
