using Abp.Domain.Entities.Auditing;
using ARHospitalProject.Domain.Discriminators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    [Entity(TypeShortAlias = "ARHis.PatientReport")]
    public class PatientReport : FullAuditedEntity<Guid>
    {
        public virtual string Prescription { get; set; }
        public virtual string Medication { get; set; }
        public virtual DateTime Date { get; set; }
        public Appointment Appointment { get; set; }
    }
}
