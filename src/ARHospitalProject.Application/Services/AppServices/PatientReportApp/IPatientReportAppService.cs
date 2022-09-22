using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.MedicalRecordApp
{
    public interface IPatientReportAppService : IApplicationService
    {
        Task<PatientReportDto> CreateAsync(PatientReportDto input);
     Task<PatientReportDto> UpdateAsync(PatientReportDto input);
        Task<PagedResultDto<PatientReportDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<PatientReportDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task DeleteAsync(Guid id);
    }
}
