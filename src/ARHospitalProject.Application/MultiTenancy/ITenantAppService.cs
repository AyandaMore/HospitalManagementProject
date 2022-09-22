using Abp.Application.Services;
using ARHospitalProject.MultiTenancy.Dto;

namespace ARHospitalProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

