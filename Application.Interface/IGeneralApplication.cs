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
        Task<Response<List<ComboModelDto.XId>>> GetTipoVia();
        Task<Response<List<ComboModelDto.XId>>> GetCentroPoblado();
        Task<Response<List<ComboModelDto.XId>>> GetNumeroManzana();
        Task<Response<List<ComboModelDto.XId>>> GetLoteInterior();
        Task<Response<List<ComboModelDto.XCodigo>>> GetDepartamento();
        Task<Response<List<ComboModelDto.XCodigo>>> GetProvincia(string sCodDepartamento);
        Task<Response<List<ComboModelDto.XCodigo>>> GetDistrito(string sCodDepartamento, string sCodProvincia);
        Task<Response<List<ComboModelDto.XId>>> GetTipoDoc(string sTipoConsulta);
        Task<Response<List<ComboModelDto.XId>>> GetTipoOperador(string sTipoConsulta);
        Task<Response<List<ComboModelDto.XId>>> GetCargoRepresentanteLegal();
    }
}
