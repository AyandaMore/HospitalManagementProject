using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain.Enums
{
    public enum RefListProvince:int
    {
        [Description("1. Gauteng")]
        Gauteng = 1,

        [Description("2. Mpumalanga")]
        Mpumalanga = 2,

        [Description("3. Limpopo")]
        Limpopo = 3,

        [Description("4. North-West")]
        NorthWest = 4,

        [Description("5. Eastern Cape")]
        EasternCape = 5,

        [Description("6. Western Cape")]
        WesternCape = 6,

        [Description("7. Free-State")]
        FreeState = 7,

        [Description("8. KwaZulu-Natal")]
        KwaZuluNatal = 8,

        [Description("9. Northern Cape")]
        NorthernCape = 9
    }
}
