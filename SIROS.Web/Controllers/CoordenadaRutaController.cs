using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Authorize(Roles = "OGTU")]
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class CoordenadaRutaController : ControllerBase
    {
        private readonly ICoordenadaRutaApplication _coordenadaRutaApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public CoordenadaRutaController(
            ICoordenadaRutaApplication coordenadaRutaApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._coordenadaRutaApplication = coordenadaRutaApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet]
        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int nPagina, string sFilter)
        {
            try
            {
                int nCantidadXPagina = 8;
                /*
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    sFilter = $"{sFilter}@{oUserInfo.Data.nIdEmpresa}";
                }
                */
                return await _coordenadaRutaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Ruta-GetAllByFilter", ex, nPagina, sFilter);
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
    }
}
