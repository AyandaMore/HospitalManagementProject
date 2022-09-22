using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain.Enums
{
    public enum RefListAppointmentStatus: int
    {
        [Description("1. Unattended")]
        Unattended = 1,

        [Description("2. Attended")]
        Attended = 2,

        [Description("3. Cancelled")]
        Cancelled = 3

    }
}
