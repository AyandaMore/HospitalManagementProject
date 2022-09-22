using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.HospitalApp
{
    public class HospitalMappingProfile: Profile
    {
        public HospitalMappingProfile()
        {
            CreateMap<Hospital, HospitalDto>();

            CreateMap<HospitalDto, Hospital>()
                .ForAllMembers(e => e.Condition((src, dest, member) => member != null));//ignore all things not in dto
                //will update fields specified only
        }
    }
}
