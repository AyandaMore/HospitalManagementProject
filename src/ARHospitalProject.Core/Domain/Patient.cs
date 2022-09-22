using ARHospitalProject.Domain.Discriminators;
using ARHospitalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{
    [Entity(TypeShortAlias = "ARHis.Patient")]
    [DiscriminatorValue("ARHis.Patient")]

    public class Patient: Person
    {
        public virtual RefListFundingType FundingType { get; set; }

    }
}
