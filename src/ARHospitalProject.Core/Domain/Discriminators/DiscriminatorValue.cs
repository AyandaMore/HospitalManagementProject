using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Domain.Discriminators
{
    public class DiscriminatorValue: Attribute
    {
        public object Value { get; set; }
        public DiscriminatorValue(object value)
        {
            Value = value;
        }
    }
}
