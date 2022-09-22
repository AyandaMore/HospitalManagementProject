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
    [AutoMap(typeof(Receptionist))]
    public class ReceptionistDto: PersonDto
    {
        public string OfficeLocation { get; set; }
        public string OfficeContactNumber { get; set; }
        public string Password { get; set; }
        public Guid? HospitalId { get; set; }

    }
}
