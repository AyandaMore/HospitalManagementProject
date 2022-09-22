using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.DoctorApp
{
    public interface IDoctorAppService : IApplicationService
    {
        Task<DoctorDto> CreateAsync(DoctorDto input);

        Task<PagedResultDto<DoctorDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

        Task<PagedResultDto<DoctorDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task<DoctorDto> UpdateAsync(DoctorDto input);

        Task DeleteAsync(Guid id);

    }
}
