using System.Threading.Tasks;
using Abp.Application.Services;
using ARHospitalProject.Authorization.Accounts.Dto;

namespace ARHospitalProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
