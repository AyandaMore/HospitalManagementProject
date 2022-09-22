using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ARHospitalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.Dto
{
    [AutoMap(typeof(DoctorAvailability))]
    public class DoctorAvailabilityDto : EntityDto<Guid>
    {
        public DateTime? DateUpdated { get; set; }

        public DateTime? AvailableFrom { get; set; }

        public DateTime? AvailableUntil { get; set; }

        public string OfficeLocation { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? HospitalId { get; set; }
    }
}
