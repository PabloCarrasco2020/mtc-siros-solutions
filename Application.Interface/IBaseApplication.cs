using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Transversal.Common;

namespace Application.Interface
{
    public interface IBaseApplication<T_RQInsert,T_RQUpdate,T_RSGET,T_RSCOMBO>
    {
        Task<Response<int>> Insert(T_RQInsert input);
        Task<Response<int>> Update(T_RQUpdate input);
        Task<Response<T_RSGET>> Get(string input);
        Task<Response<IndexTableModelDto>> GetAllByFilter(int pagina, string filter);
        Task<Response<List<T_RSCOMBO>>> GetCombo(string input);
    }
}
