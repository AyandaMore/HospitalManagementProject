using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.DoctorAvailabilityApp
{
    public interface IDoctorAvailabilityAppService : IApplicationService
    {
        Task<DoctorAvailabilityDto> CreateAsync(DoctorAvailabilityDto input);
        Task<DoctorAvailabilityDto> UpdateAsync(DoctorAvailabilityDto input);
        Task<PagedResultDto<DoctorAvailabilityDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<DoctorAvailabilityDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task DeleteAsync(Guid id);
    }
}
