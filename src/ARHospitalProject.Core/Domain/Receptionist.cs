using ARHospitalProject.Domain.Discriminators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain
{

    [Entity(TypeShortAlias = "ARHis.Receptionist")]
    [DiscriminatorValue("ARHis.Receptionist")]
    public class Receptionist : Person
    {
        public string OfficeLocation { get; set; }
        public virtual string OfficeContactNumber { get; set; }
        public virtual string Password { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}


