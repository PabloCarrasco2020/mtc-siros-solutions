using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Authorize(Roles = "Promovilidad")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CombustibleController : ControllerBase
    {
        private readonly ICombustibleApplication _combustibleApplication;
        private readonly ISSOApplication _sSOApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public CombustibleController(
            ICombustibleApplication combustibleApplication,
            ILogApplication logApplication
            )
        {
            this._combustibleApplication = combustibleApplication;
            this._logApplication = logApplication;
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int nPagina, string sFilter)
        {
            try
            {
                int nCantidadXPagina = 10;
                return await _combustibleApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combustible-GetAllByFilter", ex, nPagina, sFilter);
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

    }
}
