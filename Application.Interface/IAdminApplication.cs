﻿using Application.Dto;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IAdminApplication
    {
        Task<Response<int>> RegistrarSesion(AdminDto.RegistrarSesion oItem);
    }
}
