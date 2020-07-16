using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IEmpresaApplication : IBaseApplication<EmpresaDto.RQInsert, EmpresaDto.RQUpdate, EmpresaDto.RQDelete, EmpresaDto.RSGet, ComboModelDto.XId>
    {
    }
}
