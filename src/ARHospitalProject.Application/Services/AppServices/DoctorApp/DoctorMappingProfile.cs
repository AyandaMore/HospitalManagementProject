using ARHospitalProject.Authorization.Users;
using ARHospitalProject.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.DoctorApp
{
   public class DoctorMappingProfile:Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(e => e.UserName, m => m.MapFrom(e => e.User != null ? e.User.UserName : null))
                .ForMember(e => e.RoleNames, m => m.MapFrom(e => e.User != null ? e.User.Roles : null))
                .ForMember(e => e.Password, m => m.MapFrom(e => e.User != null ? e.User.Password : null));

            CreateMap<DoctorDto, User>()
                .ForMember(e => e.Id, m => m.MapFrom(e => e.UserId));

            CreateMap<User, DoctorDto>()
                .ForMember(e => e.Id, d => d.Ignore());


            CreateMap<DoctorDto, Doctor>().ForAllMembers(e => e.Condition((src, dest, member) => member != null));
        }

    }
    
}
