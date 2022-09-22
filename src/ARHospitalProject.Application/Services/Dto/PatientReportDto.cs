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
    [AutoMapFrom(typeof(PatientReport))]
    public class PatientReportDto : EntityDto<Guid>
    {
        public string Prescription { get; set; }
        public string Medication { get; set; }
        public DateTime Date { get; set; }

        public Guid? AppointmentId { get; set; }
    }
}
