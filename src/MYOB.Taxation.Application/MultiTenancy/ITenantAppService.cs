using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MYOB.Taxation.MultiTenancy.Dto;

namespace MYOB.Taxation.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
