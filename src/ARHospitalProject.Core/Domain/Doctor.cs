using ARHospitalProject.Domain.Discriminators;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    [Entity(TypeShortAlias = "ARHis.Doctor")]
    [DiscriminatorValue("ARHis.Doctor")]

    public class Doctor: Person
    {
        public virtual DateTime DateEmployed { get; set; } 
        public virtual RefListSpecialization Specialization { get; set; }

    }
}
