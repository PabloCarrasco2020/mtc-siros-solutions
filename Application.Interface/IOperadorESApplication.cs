using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IOperadorESApplication:IBaseApplication<OperadorESDto.RQInsert,OperadorESDto.RQUpdate,OperadorESDto.RQDelete,OperadorESDto.RSGet,ComboModelDto.XId>
    {
        Task<Response<OperadorESDto.RSGetXDoc>> GetXDoc(int nIdSucursalxES, int nIdTpDocumento, string sNroDocumento);
    }
}
