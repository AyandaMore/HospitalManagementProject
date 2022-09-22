
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ARHospitalProject.Domain;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.Dto
{
    [AutoMap(typeof(Person))]
    public class PersonDto : EntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public RefListGender Gender { get; set; }

        [StringLength(13)]
        public string IdentificationNumber { get; set; }
        public string PassportNumber { get; set; }
        public RefListRace Race { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress { get; set; }
        
        //Added from the user
        public string UserName { get; set; }
        public long? UserId { get; set; }
        public string Password { get; set; }
        public string[] RoleNames { get; set; }
    }
}
