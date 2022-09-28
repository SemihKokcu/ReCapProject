using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, ColorId=1,BrandId=1,DailyPrice=100,ModelYear=2000,Description="Temiz"},
                new Car{Id = 2, ColorId=1,BrandId=1,DailyPrice=220,ModelYear=2002,Description="Daha Temiz"},
                new Car{Id = 3, ColorId=2,BrandId=2,DailyPrice=330,ModelYear=2005,Description="Daha Daha Temiz"},
                new Car{Id = 4, ColorId=3,BrandId=2,DailyPrice=330,ModelYear=2006,Description="Çok Daha Temiz"},
                new Car{Id = 5, ColorId=4,BrandId=2,DailyPrice=400,ModelYear=2009,Description="Aşırı Çok Daha Temiz"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUptade = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUptade.BrandId = car.BrandId;
            carToUptade.DailyPrice = car.DailyPrice;
            carToUptade.ModelYear = car.ModelYear;
            carToUptade.Description = car.Description;

        }
    }
}
