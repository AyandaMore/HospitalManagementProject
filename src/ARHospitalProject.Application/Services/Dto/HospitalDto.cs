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
    [AutoMap(typeof(Hospital))]
    public class HospitalDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public RefListProvince Province { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

    }

}
