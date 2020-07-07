using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Transversal.Common;

namespace Application.Core
{
    public class MunicipalidadApplication:IMunicipalidadApplication
    {
        private readonly IMunicipalidadDomain _municipalidadDomain;
        private readonly IMapper _mapper;

        public MunicipalidadApplication(IMunicipalidadDomain municipalidadDomain, IMapper mapper)
        {
            this._municipalidadDomain = municipalidadDomain;
            this._mapper = mapper;
        }

        public async Task<Response<MunicipalidadDto.RSGet>> Get(string input)
        {
            //try
            //{
            //    var responseGet = new Response<MunicipalidadDto.RSGet>();
            //    var result = await this._municipalidadDomain.Get(new TM_MUNICIPALIDAD { NID = Int32.Parse(input) });
            //    if (result == null)
            //    {
            //        responseGet.Message = "No se encontró registro";
            //        return responseGet;
            //    }
            //    responseGet.IsSuccess = true;
            //    responseGet.Data = this._mapper.Map<MunicipalidadDto.RSGet>(result);
            //    return responseGet;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int pagina, string filter)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var responseGetAllByFilter = new Response<IndexTableModelDto>();
            //    var result = await this._municipalidadDomain.GetAllByFilter(pagina, filter);
            //    if (result.Count > 0)
            //    {
            //        responseGetAllByFilter.IsSuccess = true;
            //        responseGetAllByFilter.Data = new IndexTableModelDto();
            //        responseGetAllByFilter.Data.ActualPage = pagina;
            //        responseGetAllByFilter.Data.TotalPage = result[0].NPAGINAS;
            //        responseGetAllByFilter.Data.NroItems = result[0].NREGISTROS;
            //        responseGetAllByFilter.Data.Items = this._mapper.Map<List<TableModel>>(result);
            //    }
            //    else
            //    {
            //        responseGetAllByFilter.Message = "No se encontró registros";
            //    }
            //    return responseGetAllByFilter;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetCombo(string input)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var responseGetCombo = new Response<List<ComboModelDto>>();
            //    var result = await this._municipalidadDomain.GetCombo(new TM_MUNICIPALIDAD { });
            //    if (result.Count > 0)
            //    {
            //        responseGetCombo.IsSuccess = true;
            //        responseGetCombo.Data = this._mapper.Map<List<ComboModelDto>>(result);
            //    }
            //    else
            //    {
            //        responseGetCombo.Message = "No se encontró registros";
            //    }
            //    return responseGetCombo;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public async Task<Response<int>> Insert(MunicipalidadDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_MUNICIPALIDAD>(input);
                var result = await this._municipalidadDomain.Insert(modelReq);
                if(result > 0)
                {

                }else if(result== 0){

                }
                else
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result;
                }
                return responseInsert;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<Response<int>> Update(MunicipalidadDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
