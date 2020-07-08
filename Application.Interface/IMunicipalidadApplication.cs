using System;
using Application.Dto;

namespace Application.Interface
{
    public interface IMunicipalidadApplication:IBaseApplication<MunicipalidadDto.RQInsert,MunicipalidadDto.RQUpdate,MunicipalidadDto.RQDelete,MunicipalidadDto.RSGet,ComboModelDto.XId>
    {
    }
}
