using System;
using System.Collections.Generic;
using System.Text;
using BizCover.Api.Cars.Services;
using Xunit;
using NSubstitute;
using FluentAssertions;
using BizCover.Api.Cars.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BizCover.Api.Cars.Tests
{
    public class CarsControllerTests
    {
        private readonly ICarService _carService;
        private readonly ICarDiscountService _carDiscountService;
        private readonly CarsController _carsConroller;

        public CarsControllerTests()
        {
            _carService = Substitute.For<ICarService>();
            _carDiscountService = Substitute.For<ICarDiscountService>();

            _carsConroller = new CarsController(_carService, _carDiscountService);
        }

        [Fact]
        public void Controller_Should_Have_Correct_Route()
        {
            typeof(CarsController).Should().BeDecoratedWith<RouteAttribute>(attr => attr.Template == "api/Cars");
        }

        [Fact]
        public void GetCars_should_have_correct_Route()
        {
            var method = typeof(CarsController).GetMethod(nameof(_carsConroller.GetCars));

            method.Should().BeDecoratedWith<HttpGetAttribute>(attr => attr.Template == "getCars");
        }

    }
}
