using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IOperadorESApplication:IBaseApplication<OperadorESDto.RQInsert,OperadorESDto.RQUpdate,OperadorESDto.RQDelete,OperadorESDto.RSGet,ComboModelDto.XId>
    {
    }
}
