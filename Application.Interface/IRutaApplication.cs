using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IRutaApplication : IBaseApplication<RutaDto.RQInsert, RutaDto.RQUpdate, RutaDto.RQDelete, RutaDto.RSGet, ComboModelDto.XId>
    {
    }
}
