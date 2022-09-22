using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.PersonApp
{
    public interface IPersonAppService : IApplicationService
    {
        Task<PersonDto> CreateAsync(PersonDto input);

        Task<PagedResultDto<PersonDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

        Task<PagedResultDto<PersonDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);

        Task<PersonDto> UpdateAsync(PersonDto input);

        Task DeleteAsync(Guid id);
    
    }
}
