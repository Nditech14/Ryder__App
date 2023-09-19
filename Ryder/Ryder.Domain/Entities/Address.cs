using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ryder.Domain.Common;

namespace Ryder.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Country { get; set; }
    }
}