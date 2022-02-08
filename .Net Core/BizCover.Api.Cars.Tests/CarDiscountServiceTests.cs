using BizCover.Api.Cars.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using FluentAssertions;
using System.Threading.Tasks;
using BizCover.Repository.Cars;
using BizCover.Api.Cars.Models;

namespace BizCover.Api.Cars.Tests
{
    
    public class CarDiscountServiceTests
    {
        private readonly ICarService _carService;
        private readonly ICarDiscountService _carDiscountService;

        public  CarDiscountServiceTests()
        {
            _carService = Substitute.For<ICarService>();

            _carDiscountService = new CarDiscountService(_carService);
        }

        [Theory]
        [InlineData (1999, 10000, 2000, 10000, 1900)]
        [InlineData(2001, 10000, 2000, 10000, 900)]
        public async Task CarDiscountService_Should_return_discount(int car1Year, decimal car1Price, int car2Year, decimal car2Price,double result)
        {
            _carService.GetCars().ReturnsForAnyArgs(
                new List<Car>
                {
                    new Car
                    {
                        Id =1,
                        Colour ="Red",
                        CountryManufactured ="Australia",
                        Make="Honda",
                        Model="City",
                        Price=car1Price,
                        Year= car1Year
                    },
                     new Car
                    {
                        Id =2,
                        Colour ="Red",
                        CountryManufactured ="Australia",
                        Make="Honda",
                        Model="City",
                        Price=car2Price,
                        Year=car2Year
                    },
                    new Car
                    {
                        Id =3,
                        Colour ="Red",
                        CountryManufactured ="Australia",
                        Make="Honda",
                        Model="City",
                        Price=10000,
                        Year=2000
                    }
                }
                );

            var selectedCars = new CarsDiscountRequest
            {
                CarIds = new List<int> { 1, 2, 3}
            };

            var response = _carDiscountService.CalculateCarsDiscount(selectedCars);

            response.Result.TotalDiscountApplied.Should().Be(result);
        }
    }
}
