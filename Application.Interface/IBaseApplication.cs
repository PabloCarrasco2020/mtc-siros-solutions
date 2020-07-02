using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Transversal.Common;

namespace Application.Interface
{
    public interface IBaseApplication<RQInsert,RQUpdate,RSGET>
    {
        Task<Response<int>> Insert(RQInsert input);
        Task<Response<int>> Update(RQUpdate input);
        Task<Response<RSGET>> Get(string input);
        Task<Response<IndexTableModelDto>> GetAllByFilter(int pagina, string filter);
        Task<Response<List<ComboModelDto>>> GetCombo(string input);
    }
}
