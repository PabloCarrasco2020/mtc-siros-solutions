﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIROS.Web.Controllers
{
    [Authorize]
    [Route("api/[Controller]/[Action]")]
    public class ComboController : ControllerBase
    {
        private readonly IEstacionServicioApplication _estacionServicioApplication;
        private readonly ISucursalESApplication _sucursalEsApplication;
        private readonly ICombustibleApplication _combustibleApplication;
        private readonly IRutaApplication _rutaApplication;
        private readonly IGeneralApplication _generalApplication;
        private readonly IJwtApplication _jwtApplication;
        private readonly ILogApplication _logApplication;

        public ComboController(
            IEstacionServicioApplication estacionServicioApplication,
            ISucursalESApplication sucursalEsApplication,
            ICombustibleApplication combustibleApplication,
            IRutaApplication rutaApplication,
            IGeneralApplication generalApplication,
            IJwtApplication jwtApplication,
            ILogApplication logApplication)
        {
            this._estacionServicioApplication = estacionServicioApplication;
            this._sucursalEsApplication = sucursalEsApplication;
            this._combustibleApplication = combustibleApplication;
            this._rutaApplication = rutaApplication;
            this._generalApplication = generalApplication;
            this._jwtApplication = jwtApplication;
            this._logApplication = logApplication;
        }

        #region Ubigeo
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XCodigo>>> GetDepartamento()
        {
            try
            {
                return await this._generalApplication.GetDepartamento();
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetDepartamento", ex);
                return new Response<List<ComboModelDto.XCodigo>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XCodigo>>> GetProvincia(string sCodDepartamento)
        {
            try
            {
                return await this._generalApplication.GetProvincia(sCodDepartamento);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetProvincia", ex, sCodDepartamento);
                return new Response<List<ComboModelDto.XCodigo>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XCodigo>>> GetDistrito(string sCodDepartamento, string sCodProvincia)
        {
            try
            {
                return await this._generalApplication.GetDistrito(sCodDepartamento, sCodProvincia);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetDistrito", ex, sCodDepartamento, sCodProvincia);
                return new Response<List<ComboModelDto.XCodigo>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        #endregion

        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoVia()
        {
            try
            {
                return await this._generalApplication.GetTipoVia();
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetTipoVia", ex);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetCentroPoblado()
        {
            try
            {
                return await this._generalApplication.GetCentroPoblado();
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetCentroPoblado", ex);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetNumeroManzana()
        {
            try
            {
                return await this._generalApplication.GetNumeroManzana();
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetNumeroManzana", ex);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetLoteInterior()
        {
            try
            {
                return await this._generalApplication.GetLoteInterior();
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetLoteInterior", ex);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTipoConsulta">
        /// 'MUN' = Representante legal de Municipalidad 
        /// 'ES' = Representante legal de Estacion de servicio
        /// 'EMP' = Representante legal de Empresa
        /// 'OPESUC' =  Operador de sucursal de estacion de servicio
        /// 'OPEEMP' = Operador de empresa
        ///</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoDoc(string sTipoConsulta)
        {
            try
            {
                return await this._generalApplication.GetTipoDoc(sTipoConsulta);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetTipoDoc", ex, sTipoConsulta);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTipoConsulta">
        /// 'OPESUC' =  Operador de sucursal de estacion de servicio
        /// 'OPEEMP' = Operador de empresa
        ///</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoOperador(string sTipoConsulta)
        {
            try
            {
                return await this._generalApplication.GetTipoOperador(sTipoConsulta);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetTipoOperador", ex, sTipoConsulta);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetCargoRepresentanteLegal()
        {
            try
            {
                return await this._generalApplication.GetCargoRepresentanteLegal();
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetCargoRepresentanteLegal", ex);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetEstacionServicio()
        {
            try
            {
                return await this._estacionServicioApplication.GetCombo(null);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetEstacionServicio", ex);
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRutas()
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                var oResult = await this._rutaApplication.GetCombo(oUserInfo.Data.nIdEmpresa.ToString());
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetRutas", ex);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCombustibles()
        {
            try
            {
                var oResult = await this._combustibleApplication.GetCombo(null);
                return Ok(oResult);
            } 
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GetCombustibles", ex);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GeEstacionServicioXEntidad()
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                var oResult = await this._estacionServicioApplication.GetComboEstXEnt(oUserInfo.Data.nIdEmpresa.ToString());
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GeEstacionServicioXEntidad", ex);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GeSucursalesXEst(int nIdEstServicio)
        {
            try
            {
                var oResult = await this._sucursalEsApplication.GetCombo(nIdEstServicio.ToString());
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Combo-GeSucursalesXEst", ex);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }
    }
}
