using ARHospitalProject.Authorization.Users;
using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.ReceptionistApp
{
   public class ReceptionistMappingProfile: Profile
    {
        public ReceptionistMappingProfile()
        {


            CreateMap<Receptionist, ReceptionistDto>()
            .ForMember(e => e.UserName, m => m.MapFrom(e => e.User != null ? e.User.UserName : null))
            .ForMember(e => e.RoleNames, m => m.MapFrom(e => e.User != null ? e.User.Roles : null))
            .ForMember(e => e.Password, m => m.MapFrom(e => e.User != null ? e.User.Password : null));




            CreateMap<ReceptionistDto, User>()
                .ForMember(e => e.Id, m => m.MapFrom(e => e.UserId));

            CreateMap<User, ReceptionistDto>()
                .ForMember(e => e.Id, d => d.Ignore());


            CreateMap<ReceptionistDto, Receptionist>().ForAllMembers(e => e.Condition((src, dest, member) => member != null));
        }
    }
}
