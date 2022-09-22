using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ARHospitalProject.Domain;
using ARHospitalProject.Domain.Enums;
using ARHospitalProject.Services.Dto;
using System;

namespace ARHospitalProject.Services.AppServices.DoctorApp
{
    [AutoMap(typeof(Doctor))]
    public class DoctorDto : PersonDto
    {
   
        public DateTime DateEmployed { get; set; }
        public RefListSpecialization Specialization { get; set; }


    }
}