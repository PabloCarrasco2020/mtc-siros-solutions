using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class AdminDomain : IAdminDomain
    {
        private readonly IAdminRepository _adminRepository;

        public AdminDomain(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<ADMIN.TM_SESION> RegistrarSesion(ADMIN.TM_SESION oItem)
        {
            try
            {
                return await this._adminRepository.RegistrarSesion(oItem);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
