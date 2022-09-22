using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain.Enums
{
    public enum RefListSpecialization:int
    {
        [Description("1. General Practitioner")]
        GeneralPractitioner = 1,


        [Description("2. Cardiologist")]
        Cardiologist = 2,

        [Description("3. Dermatologist")]
        Dermatologist = 3,

        [Description("4. Neurologist")]
        Neurologist = 4,

        [Description("5. Obstetrician")]
        Obstetrician = 5,

        [Description("6. Gynaecologist")]
        Gynaecologist = 6,

        [Description("7. Oncologist")]
        Oncologist = 7,

        [Description("8. Pediatrician")]
        Pediatrician = 8,

        [Description("9. Psychiatrist")]
        Psychiatrist = 9,

        [Description("10. Radiologist")]
        Radiologist = 10,

        [Description("11. General Surgeon")]
        GeneralSurgeon = 11
    }
}
