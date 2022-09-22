using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain.Enums
{
    public enum RefListFundingType:int
    {
        [Description("0. None")]
        None = 0,


        [Description("1. Medical Aid")]
        MedicalAid = 1,

        [Description("2. Cash")]
        Cash = 2



    }
}
