using Abp.Domain.Entities.Auditing;
using ARHospitalProject.Domain.Discriminators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    [Entity(TypeShortAlias = "ARHis.DoctorAvaliability")]
    public class DoctorAvailability: FullAuditedEntity<Guid>
    {
        public virtual DateTime DateUpdated { get; set; }

        public virtual DateTime AvailableFrom { get; set; }

        public virtual DateTime AvailableUntil { get; set; }

        public virtual string OfficeLocation { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Hospital Hospital { get; set; }

    }
}
