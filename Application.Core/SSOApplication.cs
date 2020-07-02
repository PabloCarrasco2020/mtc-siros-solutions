using System;
using System.Threading.Tasks;
using Application.Interface;
using Transversal.Common;

namespace Application.Core
{
    public class SSOApplication:ISSOApplication
    {
        public SSOApplication()
        {
        }

        public Task<Response<int>> Login()
        {
            throw new NotImplementedException();
        }
    }
}
