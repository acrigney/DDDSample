using System.Threading.Tasks;
using Abp.Application.Services;
using MYOB.Taxation.Sessions.Dto;

namespace MYOB.Taxation.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
