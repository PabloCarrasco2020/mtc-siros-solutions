using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IVehiculoRutaEmpresaApplication : IBaseApplication<VehiculoRutaEmpresaDto.RQInsert, VehiculoRutaEmpresaDto.RQUpdate, VehiculoRutaEmpresaDto.RQDelete, VehiculoRutaEmpresaDto.RSGet, ComboModelDto.XId>
    {
    }
}
