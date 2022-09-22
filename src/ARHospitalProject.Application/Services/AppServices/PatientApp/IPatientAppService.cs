using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ARHospitalProject.Domain.Patient;

namespace ARHospitalProject.Services.AppServices.PatientApp
{
    public interface IPatientAppService : IApplicationService
    {
        Task<PatientDto> CreateAsync(PatientDto input);

        Task<PagedResultDto<PatientDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

        Task<PagedResultDto<PatientDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task<PatientDto> UpdateAsync(PatientDto input);

        Task DeleteAsync(Guid id);
  

    }
}
