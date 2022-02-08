using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizCover.Api.Cars.Models
{
    public class CarsDiscountResponse
    {
        public int Status { get; set; }
        public string Error { get; set; }
        public double TotalDiscountApplied { get; set; }
    }
}
