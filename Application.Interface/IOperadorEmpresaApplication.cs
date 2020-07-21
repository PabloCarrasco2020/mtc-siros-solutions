using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IOperadorEmpresaApplication : IBaseApplication<OperadorEmpresaDto.RQInsert, OperadorEmpresaDto.RQUpdate, OperadorEmpresaDto.RQDelete, OperadorEmpresaDto.RSGet, ComboModelDto.XId>
    {

    }
}
