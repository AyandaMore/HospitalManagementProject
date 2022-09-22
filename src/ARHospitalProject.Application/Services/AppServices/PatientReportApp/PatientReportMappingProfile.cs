using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.MedicalRecordApp
{
    public class PatientReportMappingProfile : Profile
    {
        public PatientReportMappingProfile()
        {
            CreateMap<PatientReport, PatientReportDto>();

            CreateMap<PatientReportDto, PatientReport>()
                .ForAllMembers(e => e.Condition((src, dest, member) => member != null));
        }

    }
}
