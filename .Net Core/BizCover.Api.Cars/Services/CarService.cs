using BizCover.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BizCover.Api.Cars.Models;

namespace BizCover.Api.Cars.Services
{
    public class CarService : ICarService
    {
        public async Task<AddCarResponse> AddCar(Car car)
        {
            try
            {
                var carRepository = new CarRepository();

                var response = await carRepository.Add(car);

                return new AddCarResponse
                {
                    Status = 200,
                    CarId = response
                };
            }
            catch (Exception ex)
            {
                return new AddCarResponse
                {
                    Status = 400,
                    Error = $"Bad request: {ex.Message}"
                };
            }
        }

        public async Task<List<Car>> GetCars()
        {
            var carRepository = new CarRepository();

            return await carRepository.GetAllCars();
        }

        public async Task<UpdateCarResponse> UpdateCar(Car car)
        {
            try
            {
                var carRepository = new CarRepository();

                await carRepository.Update(car);

                return new UpdateCarResponse
                {
                    Status = 200,
                };
            }
            catch (Exception ex)
            {
                return new UpdateCarResponse
                {
                    Status = 400,
                    Error = $"Bad request {ex.Message}"
                };
            }

        }
    }
}
