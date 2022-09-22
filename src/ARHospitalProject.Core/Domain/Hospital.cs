using Abp.Domain.Entities.Auditing;
using ARHospitalProject.Domain.Discriminators;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    [Entity(TypeShortAlias = "ARHis.Hospital")]
    public class Hospital: FullAuditedEntity<Guid>
    {
        [StringLength(50)]
        public virtual string Name { get; set; }

        public virtual RefListProvince Province { get; set; }

        [StringLength(255)]
        public virtual string Address { get; set; }

        [StringLength(15)]
        public virtual string ContactNumber { get; set; }
    }
}
