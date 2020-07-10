using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IEstacionServicioApplication: IBaseApplication<EstacionServicioDto.RQInsert,EstacionServicioDto.RQUpdate,EstacionServicioDto.RQDelete,EstacionServicioDto.RSGet,ComboModelDto.XId>
    {
    }
}
