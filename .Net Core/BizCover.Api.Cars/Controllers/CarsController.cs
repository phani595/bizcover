using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BizCover.Api.Cars.Services;
using BizCover.Repository.Cars;
using BizCover.Api.Cars.Models;

namespace BizCover.Api.Cars.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private const int Success = 200;

        private readonly ICarService _carService;
        private readonly ICarDiscountService _carDiscountService;
        public CarsController(ICarService carService, ICarDiscountService carDiscountService)
        {
            _carService = carService;
            _carDiscountService = carDiscountService;
        }
       
        [HttpGet("getCars")]
        public  ActionResult<IEnumerable<Car>> GetCars()
        {
            var cars =  _carService.GetCars().Result;

            return cars;
        }
       
        [HttpPost("addCar")]
        public ActionResult<AddCarResponse> AddCar([FromBody] Car request)
        {
            var response = _carService.AddCar(request);

            if (response.Result.Status == Success)
            {
                return response.Result;
            }

            return new BadRequestObjectResult(response.Result);
        }

        [HttpPut("updateCar")]
        public ActionResult<UpdateCarResponse> UpdateCar([FromBody] Car request)
        {
            var response = _carService.UpdateCar(request);


            if (response.Result.Status == Success)
            {
                return response.Result;
            }

            return new BadRequestObjectResult(response.Result);
        }

        [HttpPost("calculateCarsDiscount")]
        public ActionResult<CarsDiscountResponse> CalculateDiscount([FromBody] CarsDiscountRequest request)
        {
            var response = _carDiscountService.CalculateCarsDiscount(request);

            if (response.Result.Status == Success)
            {
                return response.Result;
            }

            return new BadRequestObjectResult(response.Result);
        }


    }
}
