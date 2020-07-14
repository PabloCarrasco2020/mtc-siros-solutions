using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface ICombustibleApplication: IBaseApplication<CombustibleDto.RQInsert, CombustibleDto.RQUpdate, CombustibleDto.RQDelete,CombustibleDto.RSGet, ComboModelDto.XId>
    {
    }
}
