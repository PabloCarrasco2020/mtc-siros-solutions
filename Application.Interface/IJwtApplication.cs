using Application.Dto;
using System.Security.Claims;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IJwtApplication
    {
        Task<Response<JwtDto.Response>> GenerateJwtToken(JwtDto.Request oItem);
        Task<Response<JwtDto.Request>> GetUserInfo(ClaimsPrincipal oUser);
    }
}
