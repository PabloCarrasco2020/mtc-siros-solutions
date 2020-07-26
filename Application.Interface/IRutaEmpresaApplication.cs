using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IRutaEmpresaApplication : IBaseApplication<RutaEmpresaDto.RQInsert, RutaEmpresaDto.RQUpdate, RutaEmpresaDto.RQDelete, RutaEmpresaDto.RSGet, ComboModelDto.XId>
    {
    }
}
