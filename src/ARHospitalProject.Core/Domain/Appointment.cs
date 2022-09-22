using Abp.Domain.Entities.Auditing;
using ARHospitalProject.Domain.Discriminators;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    
    public class Appointment: FullAuditedEntity<Guid>
    {
        public virtual DateTime BookingTime { get; set; }

        public virtual DateTime EndingTime { get; set; }

        public virtual RefListAppointmentStatus Status { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Hospital Hospital { get; set; }

    }
}
