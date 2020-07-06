using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IGeneralApplication
    {
        Task<Response<List<ComboModelDto>>> GetTipoVia();
        Task<Response<List<ComboModelDto>>> GetCentroPoblado();
        Task<Response<List<ComboModelDto>>> GetNumeroManzana();
        Task<Response<List<ComboModelDto>>> GetLoteInterior();
        Task<Response<List<ComboModelDto>>> GetDepartamento();
        Task<Response<List<ComboModelDto>>> GetProvincia(string sCodDepartamento);
        Task<Response<List<ComboModelDto>>> GetDistrito(string sCodDepartamento, string sCodProvincia);
        Task<Response<List<ComboModelDto>>> GetTipoDocRepresentanteLegal();
        Task<Response<List<ComboModelDto>>> GetCargoRepresentanteLegal();
    }
}
