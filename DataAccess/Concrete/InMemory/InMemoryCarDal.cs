using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {CarId=1, BrandId=1, ColorId=1, ModelYear=2009, DailyPrice=220.99M, CarName="Toyota"},
                new Car {CarId=2, BrandId=1, ColorId=3, ModelYear=2012, DailyPrice=320, CarName="Toyota"},
                new Car {CarId=3, BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=380.90M, CarName="Mercedes"},
                new Car {CarId=4, BrandId=3, ColorId=2, ModelYear=2022, DailyPrice=350, CarName="Renault"},
                new Car {CarId=5, BrandId=4, ColorId=2, ModelYear=2015, DailyPrice=420.99M, CarName="BMW"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteCar = _cars.SingleOrDefault(c => c.CarId == car.CarId)!;
            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null!)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarsDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updateCar = _cars.SingleOrDefault(c => c.CarId == car.CarId)!;
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.ModelYear = car.ModelYear;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.CarName = car.CarName;
        }
    }
}