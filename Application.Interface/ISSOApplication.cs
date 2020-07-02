using System;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface ISSOApplication
    {
        Task<string> AuthMiddleWare();
        Task<Response<int>> Login(string headerToken, string userName, string userPassword);
    }
}
