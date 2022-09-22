using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ARHospitalProject.Authorization;
using ARHospitalProject.Authorization.Users;
using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using ARHospitalProject.Services.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.AppointmentApp
{
    public class AppointmentAppService : ApplicationService, IAppointmentAppService
    {
        private readonly IRepository<Appointment, Guid> _appointmentRepository;
        private readonly IRepository<Doctor, Guid> _doctorRepository;
        private readonly IRepository<Patient, Guid> _patientRepository;
        private readonly IRepository<Hospital, Guid> _hospitalRepository;
        private readonly IRepository<DoctorAvailability, Guid> _doctorAvailabilityRepository;
        private readonly UserManager _userManager;
        private int isAppointmentReserved;

        public AppointmentAppService(IRepository<Appointment, Guid> appointmentRepository, IRepository<Doctor, Guid> doctorRepository, IRepository<Patient, Guid> patientRepository, IRepository<Hospital, Guid> hospitalRepository, IRepository<DoctorAvailability, Guid> doctorAvailabiltyRepository, UserManager userManager)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _hospitalRepository = hospitalRepository;
            _doctorAvailabilityRepository = doctorAvailabiltyRepository;
            _userManager = userManager;

        }

        [AbpAuthorize(PermissionNames.Pages_Create_Appointment)]
        public async Task<AppointmentDto> CreateAsync(AppointmentDto input)
        {
            if (input.EndingTime >= input.BookingTime)
                throw new UserFriendlyException("");

            if (input.BookingTime <= DateTime.Now)
                throw new UserFriendlyException("It's too late to schedule an appointment");

            if (input.BookingTime.Date != input.EndingTime.Date)
                throw new UserFriendlyException("Dates do not match");

            var isDoctorAvailable = _doctorAvailabilityRepository.GetAll().Any(x => x.Doctor.Id == input.DoctorId && x.AvailableFrom >= input.BookingTime && x.AvailableUntil <= input.EndingTime);
            if (!isDoctorAvailable)
                throw new UserFriendlyException("The Doctor is not avaliable at this time, try again.");

            var isAppointmentReserved = _appointmentRepository.GetAll().Any(x => x.BookingTime >= input.BookingTime && x.EndingTime <= input.EndingTime && x.Doctor.Id == input.DoctorId);
            if (isAppointmentReserved)
                throw new UserFriendlyException("The slot is already taken.");

            var appointment = ObjectMapper.Map<Appointment>(input);

            appointment.Doctor = await _doctorRepository.GetAsync((Guid)input.DoctorId);
            appointment.Patient = await _patientRepository.GetAsync((Guid)input.PatientId);
            appointment.Hospital = await _hospitalRepository.GetAsync((Guid)input.HospitalId);

            await _appointmentRepository.InsertAsync(appointment);
            CurrentUnitOfWork.SaveChanges();

            //var cell = "+27" + appointment.Patient.CellPhoneNumber.Remove(0, 1);
            // Notification.SendMessage(cell, $"Your appointment has been successfully created with Dr {appointment.Doctor.LastName} for {appointment.BookingTime}");

            return ObjectMapper.Map<AppointmentDto>(appointment);
        }

        [AbpAuthorize(PermissionNames.Pages_Delete_Appointment)]
        public async Task DeleteAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetAsync((Guid)id);
            await _appointmentRepository.DeleteAsync(appointment);
        }

        [AbpAuthorize(PermissionNames.Pages_See_Appointment)]
        public async Task<PagedResultDto<AppointmentDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _appointmentRepository.GetAllIncluding(a => a.Doctor, m => m.Patient, h => h.Hospital); //fetching the course & also the department
            var result = new PagedResultDto<AppointmentDto>();
            result.TotalCount = query.Count();
            result.Items = ObjectMapper.Map<IReadOnlyList<AppointmentDto>>(query);
            return await Task.FromResult(result);
        }

        [AbpAuthorize(PermissionNames.Pages_See_Appointment_By_Id)]
        public async Task<PagedResultDto<AppointmentDto>> GetAsync(Guid id)
        {

            var query = _appointmentRepository.GetAllIncluding(a => a.Doctor, m => m.Patient, h => h.Hospital)
                         .Where(x => x.Doctor.Id == id).FirstOrDefault();
            var result = new PagedResultDto<AppointmentDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<AppointmentDto>>(query);
            return await Task.FromResult(result);

        }

        [AbpAuthorize(PermissionNames.Pages_Update_Appointment)]
        public async Task<AppointmentDto> UpdateAsync(AppointmentDto input)
        {
            if (input.Id != Guid.Empty)
                throw new UserFriendlyException("");

            if (input.EndingTime >= input.BookingTime)
                throw new UserFriendlyException("");

            if (input.BookingTime <= DateTime.Now)
                throw new UserFriendlyException("It's too late to schedule an appointment");

            if (input.BookingTime.Date != input.EndingTime.Date)
                throw new UserFriendlyException("Dates do not match");

            var isDoctorAvailable = _doctorAvailabilityRepository.GetAll().Any(x => x.Doctor.Id == input.DoctorId && x.AvailableFrom >= input.BookingTime && x.AvailableUntil <= input.EndingTime);
            if (!isDoctorAvailable)
                throw new UserFriendlyException("The Doctor is not avaliable at this time, try again.");

            var isAppointmentReserved = _appointmentRepository.GetAll().Any(x => x.BookingTime >= input.BookingTime && x.EndingTime <= input.EndingTime && x.Doctor.Id == input.DoctorId);
            if (isAppointmentReserved)
                throw new UserFriendlyException("The slot is already taken.");


            var appointment = _appointmentRepository.GetAllIncluding(a => a.Doctor, m => m.Patient, h => h.Hospital)
                                            .Where(x => x.Id == input.Id).FirstOrDefault();
            appointment.BookingTime = input.BookingTime;
            appointment.EndingTime = input.EndingTime;

            await _appointmentRepository.UpdateAsync(appointment);
            CurrentUnitOfWork.SaveChanges();

            //var cell = "+27" + appointment.Patient.CellPhoneNumber.Remove(0, 1);
            // Notification.SendMessage(cell, $"Your appointment has been successfully created with Dr {appointment.Doctor.LastName} for {appointment.BookingTime}");

            return ObjectMapper.Map<AppointmentDto>(appointment);
        }
    }
}
