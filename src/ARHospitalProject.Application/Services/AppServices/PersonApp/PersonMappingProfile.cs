using ARHospitalProject.Domain;
using ARHospitalProject.Services.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.PersonApp
{
    public class PersonMappingProfile:Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>().ForAllMembers(e => e.Condition((src, dest, member) => member != null));
        }
    }
    }

