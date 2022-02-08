using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Models
{
    public class CarsDiscountRequest
    {
        public List<int> CarIds { get; set; }
    }
}