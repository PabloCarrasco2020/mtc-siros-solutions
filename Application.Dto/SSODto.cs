using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class SSODto
    {
        #region Response Models

        public class SSOResponse<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }

        #endregion

        public class Authenticate
        {
            public class Request
            {
                public string Username { get; set; }
                public string Password { get; set; }
            }
        }

        public class Login
        {
            public class Request
            {
                public string ApplicationId { get; set; }
                public string TokenUser { get; set; }
                public string TokenPassword { get; set; }
                public string UserName { get; set; }
                public string UserPassword { get; set; }
            }

            public class RequestModel
            {
                public string sUsername { get; set; }
                public string sPassword { get; set; }
            }

            public class Response
            {
                public int IdUsuario { get; set; }
                public int nIdEmpresa { get; set; }
                public string sNombreEmpresa { get; set; }
                public int nIdLocal { get; set; }
                public string sNombreLocal { get; set; }
                public int nIdPerfil { get; set; }
                public string sNombrePerfil { get; set; }
                public string sToken { get; set; }
                public DateTime dTokenExpiration { get; set; }
            }
        }

        public class EnterpriseNew
        {
            public class Request
            {
                public string ApplicationId { get; set; }
                public string TokenUser { get; set; }
                public string TokenPassword { get; set; }
                public string DocumentNumber { get; set; }
            }

            public class Response
            {
                public int IdPersona { get; set; }
                public string LibretaTributaria { get; set; }
                public string RazonSocial { get; set; }
                public string NumeroRuc { get; set; }
                public string CodigoDependencia { get; set; }
                public string TipoContribuyente { get; set; }
                public string TipoPersona { get; set; }
                public string CodigoActividadEconomica { get; set; }
                public string Ubigeo { get; set; }
                public string NombreVia { get; set; }
                public string NumeroVia { get; set; }
                public string Interior { get; set; }
                public string NombreZona { get; set; }
                public string ReferenciaUbicacion { get; set; }
                public string CondicionDomicilio { get; set; }
                public string EstadoContribuyente { get; set; }
                public string FechaAlta { get; set; }
                public string FechaBaja { get; set; }
                public string CodigoTipoVia { get; set; }
                public string CodigoTipoZona { get; set; }
                public string FechaHoraActualizacion { get; set; }
                public string DomicilioLegal { get; set; }
                public string NombreComercial { get; set; }
            }
        }

        public class EnterpriseAttachApp
        {
            public class Request
            {
                public string idEmpresa { get; set; }
                public string ApplicationId { get; set; }
                public string TokenUser { get; set; }
                public string TokenPassword { get; set; }
                public string DocumentNumber { get; set; }
            }

            public class Response
            {
                public bool Success { get; set; }
                public string Key { get; set; }
                public string Value { get; set; }
            }
        }

        public class EnterpriseAddLocal
        {
            public class Request
            {
                public string idEmpresa { get; set; }
                public string ApplicationId { get; set; }
                public string TokenUser { get; set; }
                public string TokenPassword { get; set; }
                public string DocumentNumber { get; set; }
                public string IdAplicacionEmpresa { get; set; }
                public string NombreLocal { get; set; }
                public string DireccionLocal { get; set; }
            }

            public class Response
            {
                public bool Success { get; set; }
                public string Key { get; set; }
                public string Value { get; set; }
            }
        }

        public class Empresas
        {
            public class Request
            {
                public string ApplicationId { get; set; }
                public string TokenUser { get; set; }
                public string TokenPassword { get; set; }
                public string DocumentNumber { get; set; }
            }

            public class Response
            {
                public int IdEmpresa { get; set; }
                public string NombreCentro { get; set; }
                public List<ResponseLocal> Locales { get; set; }
            }

            public class ResponseLocal
            {
                public int IdLocal { get; set; }
                public string NombreLocal { get; set; }
            }
        }

        public class Perfiles
        {
            public class Request
            {
                public string ApplicationId { get; set; }
                public string TokenUser { get; set; }
                public string TokenPassword { get; set; }
                public string PersonId { get; set; }
                public string LocalId { get; set; }
            }

            public class Response
            {
                public int IdRol { get; set; }
                public string NombreRol { get; set; }
            }
        }
    }
}
