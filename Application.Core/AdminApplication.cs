using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class AdminApplication : IAdminApplication
    {
        private readonly IAdminDomain _adminDomain;
        private readonly IMapper _mapper;

        public AdminApplication(IAdminDomain adminDomain, IMapper mapper)
        {
            this._adminDomain = adminDomain;
            this._mapper = mapper;
        }

        public async Task<Response<int>> RegistrarSesion(AdminDto.RegistrarSesion oItem)
        {
            try
            {
                var oEntity = this._mapper.Map<ADMIN.TM_SESION>(oItem);
                var nResult = await this._adminDomain.RegistrarSesion(oEntity);

                var oResponse = new Response<int>();
                oResponse.IsSuccess = false;

                if (nResult.STR_ESTADOPROCESO == "1")
                {
                    oResponse.IsSuccess = true;
                    oResponse.Data = nResult.NUM_IDSESION;
                    oResponse.Message = nResult.STR_MENSAJE;
                }
                else if (nResult.STR_ESTADOPROCESO == "-1")
                {
                    oResponse.Message = nResult.STR_MENSAJE;
                }
                else if (nResult.STR_ESTADOPROCESO == "0")
                {
                    throw new Exception(nResult.STR_MENSAJE);
                }

                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
