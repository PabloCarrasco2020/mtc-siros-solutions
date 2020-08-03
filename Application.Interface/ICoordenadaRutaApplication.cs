using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface ICoordenadaRutaApplication : IBaseApplication<CoordenadaRutaDto.RQInsert, CoordenadaRutaDto.RQUpdate, CoordenadaRutaDto.RQDelete, CoordenadaRutaDto.RSGet, ComboModelDto.XId>
    {
    }
}
