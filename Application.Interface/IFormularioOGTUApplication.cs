using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IFormularioOGTUApplication:IBaseApplication<FormularioOGTUDto.RQInsert,FormularioOGTUDto.RQUpdate,FormularioOGTUDto.RQDelete,FormularioOGTUDto.RSGet,ComboModelDto.XId>
    {
    }
}
