using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.DoctorAvailabilityApp
{
    public class DoctorAvailabilityMappingProfile : Profile
    {
        public DoctorAvailabilityMappingProfile()
        {
            CreateMap<DoctorAvailability, DoctorAvailabilityDto>();

            CreateMap<DoctorAvailabilityDto, DoctorAvailability>()
                .ForAllMembers(e => e.Condition((src, dest, member) => member != null));
        }
    }
}
