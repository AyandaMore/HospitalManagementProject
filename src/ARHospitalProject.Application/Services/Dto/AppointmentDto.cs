using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ARHospitalProject.Domain;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.Dto
{
    [AutoMap(typeof(Appointment))]
    public class AppointmentDto : EntityDto<Guid>
    {
        public DateTime BookingTime { get; set; }

        public DateTime EndingTime { get; set; }
        public RefListAppointmentStatus Status { get; set; }
        public Guid? HospitalId { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
       
    }
}

