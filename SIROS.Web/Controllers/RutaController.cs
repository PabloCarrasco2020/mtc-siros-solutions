﻿using System;
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
    public class RutaController : ControllerBase
    {
        private readonly IRutaApplication _rutaApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public RutaController(
            IRutaApplication rutaApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._rutaApplication = rutaApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int nPagina, string sFilter)
        {
            try
            {
                int nCantidadXPagina = 10;
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    //sFilter = $"{sFilter}@{oUserInfo.Data.nIdEmpresa}";
                    sFilter = $"{sFilter}@1166";
                }
                return await _rutaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
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
