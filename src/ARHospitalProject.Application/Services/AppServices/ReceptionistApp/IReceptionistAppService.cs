using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.ReceptionistApp
{
    public interface IReceptionistAppService : IApplicationService
    {
        Task<ReceptionistDto> CreateAsync(ReceptionistDto input);

        Task<PagedResultDto<ReceptionistDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

        Task<PagedResultDto<ReceptionistDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task<ReceptionistDto> UpdateAsync(ReceptionistDto input);

        Task DeleteAsync(Guid id);
    }
}
