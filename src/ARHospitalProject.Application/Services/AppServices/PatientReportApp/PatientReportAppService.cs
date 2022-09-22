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

namespace ARHospitalProject.Services.AppServices.MedicalRecordApp
{
    public class PatientReportAppService : ApplicationService, IPatientReportAppService
    {
        private readonly IRepository<PatientReport, Guid> _patientReportRepository;
        private readonly IRepository<Appointment, Guid> _appointmentRepository;

        public PatientReportAppService(IRepository<PatientReport, Guid> patientReportRepository, IRepository<Appointment, Guid> appointmentRepository)
        {
            _patientReportRepository = patientReportRepository;
            _appointmentRepository = appointmentRepository;
        }

     [AbpAuthorize(PermissionNames.Pages_Create_MedicalRecord)]
        public async  Task<PatientReportDto> CreateAsync(PatientReportDto input)
        {
            var record = ObjectMapper.Map<PatientReport>(input);
            record.Appointment = await _appointmentRepository.GetAsync((Guid)input.AppointmentId);
            await _patientReportRepository.InsertAsync(record);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<PatientReportDto>(record);  
        }


    [AbpAuthorize(PermissionNames.Pages_See_MedicalRecord)]
        public async Task<PagedResultDto<PatientReportDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
 
                var query = _patientReportRepository.GetAllIncluding(a => a.Appointment); //fetching the course & also the department
                var result = new PagedResultDto<PatientReportDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<PatientReportDto>>(query);
                return await Task.FromResult(result);
           
        }


     [AbpAuthorize(PermissionNames.Pages_See_MedicalRecord_By_Id)]
        public async Task<PagedResultDto<PatientReportDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
        
                var query = _patientReportRepository.GetAllIncluding(a => a.Appointment);
                var res = query.Where(x => x.Id == id); //to get the entity with the specified ID only
                var result = new PagedResultDto<PatientReportDto>();
                result.Items = ObjectMapper.Map<IReadOnlyList<PatientReportDto>>(res);
                return await Task.FromResult(result);
          
        }

     [AbpAuthorize(PermissionNames.Pages_Update_MedicalRecord)]
        public async Task<PatientReportDto> UpdateAsync(PatientReportDto input)
        {
            var record =  _patientReportRepository.GetAllIncluding(a => a.Appointment)
                    .Where(x => x.Id == input.Id).FirstOrDefault();

            ObjectMapper.Map(input, record);
            var entity = await _patientReportRepository.UpdateAsync(record);
            return ObjectMapper.Map<PatientReportDto>(entity);
        }


    [AbpAuthorize(PermissionNames.Pages_Delete_MedicalRecord)]
        public async Task DeleteAsync(Guid id)
        {
            var record = await _patientReportRepository.GetAsync((Guid)id);
            await _patientReportRepository.DeleteAsync(record);
        }

    }

}
