using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ARHospitalProject.Authorization;
using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.HospitalApp
{
   
    public class HospitalAppService : ApplicationService, IHospitalAppService
    {
        private readonly IRepository<Hospital, Guid> _hospitalRepository;

        public HospitalAppService(IRepository<Hospital, Guid> hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        
        [AbpAuthorize(PermissionNames.Pages_Create_Hospital)]
        public async Task<HospitalDto> CreateAsync(HospitalDto input)
        {
            var hospital = ObjectMapper.Map<Hospital>(input);
            await _hospitalRepository.InsertAsync(hospital);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<HospitalDto>(hospital);
        }


        [AbpAuthorize(PermissionNames.Pages_See_Hospital)]
        public async Task<PagedResultDto<HospitalDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
                var query = _hospitalRepository.GetAllIncluding();
                var result = new PagedResultDto<HospitalDto>(); 
                result.TotalCount = query.Count(); 
                result.Items = ObjectMapper.Map<IReadOnlyList<HospitalDto>>(query);
                return await Task.FromResult(result);  
        }


        [AbpAuthorize(PermissionNames.Pages_See_Hospital_By_Id)]
        public async Task<PagedResultDto<HospitalDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
                var query = _hospitalRepository.GetAllIncluding();
                var IdResult = query.Where(data => data.Id == id); 
                var result = new PagedResultDto<HospitalDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<HospitalDto>>(IdResult);
                return await Task.FromResult(result);
        }


        [AbpAuthorize(PermissionNames.Pages_Update_Hospital)]
        public async Task<HospitalDto> UpdateAsync(HospitalDto input)
        {
            var hospital = await _hospitalRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, hospital);
            await _hospitalRepository.UpdateAsync(hospital);
            return ObjectMapper.Map<HospitalDto>(hospital);
        }


        [AbpAuthorize(PermissionNames.Pages_Delete_Hospital)]
        public async Task DeleteAsync(Guid id)
        {
            var record = await _hospitalRepository.GetAsync((Guid)id);
            await _hospitalRepository.DeleteAsync(record);
        }
    }
}
