using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IAdminRepository
    {
        Task<ADMIN.TM_SESION> RegistrarSesion(ADMIN.TM_SESION oItem);
    }
}
