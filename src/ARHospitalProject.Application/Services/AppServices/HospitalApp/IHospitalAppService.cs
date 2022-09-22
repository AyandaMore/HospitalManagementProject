using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.HospitalApp
{
   public interface IHospitalAppService : IApplicationService
    {
        Task<HospitalDto> CreateAsync(HospitalDto input);

        Task<PagedResultDto<HospitalDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

        Task<PagedResultDto<HospitalDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task<HospitalDto> UpdateAsync(HospitalDto input);

        Task DeleteAsync(Guid id);
        

    }
}
