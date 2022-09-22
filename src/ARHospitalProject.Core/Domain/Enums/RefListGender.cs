using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain.Enums
{
    public enum RefListGender: int
    {
        [Description("1. Female")]
        Female=1,

        [Description("2. Male")]
        Male = 2
    }
}
