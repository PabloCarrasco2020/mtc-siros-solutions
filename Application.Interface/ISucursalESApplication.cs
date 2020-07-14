using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface ISucursalESApplication:IBaseApplication<SucursalESDto.RQInsert,SucursalESDto.RQUpdate,SucursalESDto.RQDelete,SucursalESDto.RSGet,ComboModelDto.XId>
    {
    }
}
