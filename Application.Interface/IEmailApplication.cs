using Application.Dto;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IEmailApplication
    {
        Task<Response<EmailDto.Response>> SendEmail(EmailDto.Request oItem);
    }
}
