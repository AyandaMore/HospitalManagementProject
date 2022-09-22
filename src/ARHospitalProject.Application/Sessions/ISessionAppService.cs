using System.Threading.Tasks;
using Abp.Application.Services;
using ARHospitalProject.Sessions.Dto;

namespace ARHospitalProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
