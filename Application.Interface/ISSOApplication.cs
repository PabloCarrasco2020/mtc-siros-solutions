using Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface ISSOApplication
    {
        Task<string> AuthMiddleWare();
        //Task<Response<int>> Login(string headerToken, string userName, string userPassword);

        Task<Response<SSODto.Login.Response>> Login(SSODto.Login.RequestModel oItem);
        Task<Response<SSODto.EnterpriseNew.Response>> EnterpriseNew(string sDocumentNumber);
        Task<Response<SSODto.EnterpriseAttachApp.Response>> EnterpriseAttachApp(string sIdEmpresa, string sDocumentNumber);
        Task<Response<SSODto.EnterpriseAddLocal.Response>> EnterpriseAddLocal(
            string sIdEmpresa, 
            string sDocumentNumber, 
            string sIdAplicacionEmpresa,
            string sNombreLocal,
            string sDireccionLocal);
        Task<Response<List<SSODto.Empresas.Response>>> GetEmpresas(string sDocumentNumber);
        Task<Response<List<SSODto.Perfiles.Response>>> GetPerfiles(string sPersonId, string sLocalId);
    }
}
