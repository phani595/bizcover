using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizCover.Api.Cars.Models;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Services
{
    public interface ICarService
    {
        Task<AddCarResponse> AddCar(Car car);

        Task<List<Car>> GetCars();

        Task<UpdateCarResponse> UpdateCar(Car car);

    }
}
