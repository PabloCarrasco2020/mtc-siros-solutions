using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IEstacionServicioApplication: IBaseApplication<EstacionServicioDto.RQInsert,EstacionServicioDto.RQUpdate,EstacionServicioDto.RQDelete,EstacionServicioDto.RSGet,ComboModelDto.XId>
    {
        Task<Response<List<ComboModelDto.XId>>> GetComboEstXEnt(string input);
    }
}
