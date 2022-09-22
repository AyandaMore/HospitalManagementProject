using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ARHospitalProject.Domain;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.Dto
{
    [AutoMap(typeof(Patient))]
    public class PatientDto: PersonDto
    {
        public RefListFundingType FundingType { get; set; }

    }
}
