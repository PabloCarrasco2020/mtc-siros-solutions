using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IOngeiApplication
    {
        Task<Response<OngeiDto.OngeiResponseModel>> ConsultaCarnetExt(string sNumDoc);
    }
}
