using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MYOB.Taxation.MultiTenancy;

namespace MYOB.Taxation.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}