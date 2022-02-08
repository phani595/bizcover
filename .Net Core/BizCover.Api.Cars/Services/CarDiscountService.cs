using BizCover.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizCover.Api.Cars.Models;

namespace BizCover.Api.Cars.Services
{
    public class CarDiscountService : ICarDiscountService
    {
        private readonly ICarService _carService;

        public CarDiscountService(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<CarsDiscountResponse> CalculateCarsDiscount(CarsDiscountRequest selectedCars)
        {
            try
            {
                var carsList = await _carService.GetCars();

                var totalCarsCost = CalculateTotalCarsValue(selectedCars, carsList);

                var totaldDicsountPercentage = 0;
                if (selectedCars.CarIds.Count > 2)
                {
                    var threePercent = 3;

                    totaldDicsountPercentage += totaldDicsountPercentage + threePercent;
                }

                if (totalCarsCost > 100000)
                {
                    var fivePercent = 5;

                    totaldDicsountPercentage += totaldDicsountPercentage + fivePercent;
                }

                var totalCarsDiscsount = 0.0;

                selectedCars.CarIds.ForEach(carId =>
                {
                    var selectedCar = carsList.Find(car => car.Id == carId);
                    var totalDiscountAppliedToCar = totaldDicsountPercentage;

                    if (selectedCar.Year < 2000)
                    {
                        var additionalTenPercent = 10;
                        totalDiscountAppliedToCar += additionalTenPercent;

                    }

                    totalCarsDiscsount += Convert.ToDouble((selectedCar.Price * totalDiscountAppliedToCar) / 100);

                });

                return new CarsDiscountResponse
                {
                    TotalDiscountApplied = totalCarsDiscsount,
                    Status = 200
                };
            }
            catch(Exception ex)
            {
                return new CarsDiscountResponse
                {
                    TotalDiscountApplied = 0,
                    Status = 400,
                    Error = $"Bad request {ex.Message}"
                };
            }
        }

        private static double CalculateTotalCarsValue(CarsDiscountRequest selectedCars, List<Car> carsList)
        {
            var totalCarsCost = 0.0;

            selectedCars.CarIds.ForEach(carId =>
            {
                var selectedCar = carsList.Find(car => car.Id == carId);

                totalCarsCost += Convert.ToDouble(selectedCar.Price);

            });

            return totalCarsCost;
        }
    }
}
