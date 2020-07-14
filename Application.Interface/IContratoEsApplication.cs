using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IContratoEsApplication: IBaseApplication<ContratoEsDto.RQInsert, ContratoEsDto.RQUpdate, ContratoEsDto.RQDelete, ContratoEsDto.RSGet, ComboModelDto.XId>
    {
    }
}
