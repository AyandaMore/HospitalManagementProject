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

namespace ARHospitalProject.Services.AppServices.DoctorAvailabilityApp
{
    public class DoctorAvailabilityAppService : ApplicationService, IDoctorAvailabilityAppService
    {
        private readonly IRepository<DoctorAvailability, Guid> _doctorAvailabilityRepository;
        private readonly IRepository<Doctor, Guid> _doctorRepository;
        private readonly IRepository<Hospital, Guid> _hospitalRepository;

        public DoctorAvailabilityAppService(IRepository<DoctorAvailability, Guid> doctorAvailabilityRepository, IRepository<Doctor, Guid> doctorRepository, IRepository<Hospital, Guid> hospitalRepository) 
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
            _doctorRepository = doctorRepository;
            _hospitalRepository = hospitalRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Create_DoctorAvailability)]
        public async Task<DoctorAvailabilityDto> CreateAsync(DoctorAvailabilityDto input)
        {
            var availability = ObjectMapper.Map<DoctorAvailability>(input);
            availability.Doctor = await _doctorRepository.GetAsync((Guid)input.DoctorId);
            availability.Hospital = await _hospitalRepository.GetAsync((Guid)input.HospitalId);
            await _doctorAvailabilityRepository.InsertAsync(availability);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<DoctorAvailabilityDto>(availability);
        }

        [AbpAuthorize(PermissionNames.Pages_Delete_DoctorAvailability)]
        public async Task DeleteAsync(Guid id)
        {
            var record = await _doctorAvailabilityRepository.GetAsync((Guid)id);
            await _doctorAvailabilityRepository.DeleteAsync(record);
        }

        [AbpAuthorize(PermissionNames.Pages_See_DoctorAvailability)]
        public async Task<PagedResultDto<DoctorAvailabilityDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
           
                var query = _doctorAvailabilityRepository.GetAllIncluding(a => a.Doctor, k => k.Hospital); //fetching the course & also the department
                var result = new PagedResultDto<DoctorAvailabilityDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<DoctorAvailabilityDto>>(query);
                return await Task.FromResult(result);
          
        }

        [AbpAuthorize(PermissionNames.Pages_See_DoctorAvailability_By_Id)]
        public async Task<PagedResultDto<DoctorAvailabilityDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
                var query = _doctorAvailabilityRepository.GetAllIncluding(a => a.Doctor, x => x.Hospital)
                                    .Where(x => x.Doctor.Id == id);
                var result = new PagedResultDto<DoctorAvailabilityDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<DoctorAvailabilityDto>>(query);
                return await Task.FromResult(result);
        }

        [AbpAuthorize(PermissionNames.Pages_Update_DoctorAvailability)]
        public async Task<DoctorAvailabilityDto> UpdateAsync(DoctorAvailabilityDto input)
        {
            var availability =  _doctorAvailabilityRepository.GetAllIncluding(a => a.Doctor)
                .Where(x => x.Doctor.Id == input.Id).FirstOrDefault();
            ObjectMapper.Map(input, availability);
            var entity = await _doctorAvailabilityRepository.UpdateAsync(availability);
            return ObjectMapper.Map<DoctorAvailabilityDto>(entity);
        }
    }
}
