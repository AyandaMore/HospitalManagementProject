using ARHospitalProject.Authorization.Users;
using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ARHospitalProject.Domain.Patient;

namespace ARHospitalProject.Services.AppServices.PatientApp
{
    public class PatientMappingProfile: Profile
    {
        public PatientMappingProfile()
        {

            CreateMap<Patient, PatientDto>()
            .ForMember(e => e.UserName, m => m.MapFrom(e => e.User != null ? e.User.UserName : null))
            .ForMember(e => e.RoleNames, m => m.MapFrom(e => e.User != null ? e.User.Roles : null))
            .ForMember(e => e.Password, m => m.MapFrom(e => e.User != null ? e.User.Password : null));

            CreateMap<PatientDto, User>()
                .ForMember(e => e.Id, m => m.MapFrom(e => e.UserId));

            CreateMap<User, PatientDto>()
                .ForMember(e => e.Id, d => d.Ignore());


            CreateMap<PatientDto, Patient>().ForAllMembers(e => e.Condition((src, dest, member) => member != null));
        }
    }
    }

