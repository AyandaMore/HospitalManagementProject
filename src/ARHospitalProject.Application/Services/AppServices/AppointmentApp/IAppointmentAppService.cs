using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.AppointmentApp
{
    public interface IAppointmentAppService : IApplicationService
    {
        Task<AppointmentDto> CreateAsync(AppointmentDto input);
        Task<AppointmentDto> UpdateAsync(AppointmentDto input);
        Task<PagedResultDto<AppointmentDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<AppointmentDto>> GetAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
