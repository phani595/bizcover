using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Models
{
    public class AddCarResponse
    {
        public int Status { get; set; }
        public string Error { get; set; }
        public int CarId { get; set; }
    }
    
}
