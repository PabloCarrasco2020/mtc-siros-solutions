using System;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface ISSOApplication
    {
        Task<Response<int>> Login();
    }
}
