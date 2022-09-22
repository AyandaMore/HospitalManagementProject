using Abp.Domain.Entities.Auditing;
using ARHospitalProject.Authorization.Users;
using ARHospitalProject.Domain.Discriminators;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    [Entity(TypeShortAlias="ARHis.Person")]
    [Table("ARHis.People")]
    [DiscriminatorValue("ARHis.Person")]
    public class Person : FullAuditedEntity<Guid>
    {
        [StringLength(50)]
        public virtual string FirstName { get; set; }

        [StringLength(50)]
        public virtual string LastName { get; set; }

        public virtual DateTime? DateOfBirth { get; set; }
        public virtual RefListGender Gender { get; set; }

        [StringLength(13)]
        public virtual string IdentificationNumber { get; set; }

        [StringLength(9)]
        public virtual string PassportNumber { get; set; }

        public virtual RefListRace Race { get; set; }

        [StringLength(15)]
        public virtual string CellPhoneNumber { get; set; }

        [StringLength(50)]
        public virtual string Email { get; set; }

        [StringLength(250)]
        public virtual string PhysicalAddress { get; set; }

        public User? User { get; set; }
    }
}
