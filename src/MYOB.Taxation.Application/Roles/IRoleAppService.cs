using System.Threading.Tasks;
using Abp.Application.Services;
using MYOB.Taxation.Roles.Dto;

namespace MYOB.Taxation.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
