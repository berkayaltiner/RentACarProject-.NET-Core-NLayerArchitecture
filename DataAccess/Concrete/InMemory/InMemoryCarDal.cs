using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2017, DailyPrice=120, Description="Renault Clio Otomatik Beyaz 2017"},
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=2019, DailyPrice=120, Description="Renault Clio Manuel Gri 2019"},
                new Car{Id=3, BrandId=2, ColorId=1, ModelYear=2015, DailyPrice=150, Description="Toyota Corolla Manuel Beyaz 2015"},
                new Car{Id=4, BrandId=2, ColorId=2, ModelYear=2020, DailyPrice=150, Description="Toyota Corolla Otomatik Gri 2020"},
                new Car{Id=5, BrandId=3, ColorId=3, ModelYear=2017, DailyPrice=175, Description="Volkswagen Passat Manuel Siyah 2017"},
                new Car{Id=6, BrandId=3, ColorId=2, ModelYear=2019, DailyPrice=175, Description="Volkswagen Passat Otomatik Gri 2019"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
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

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToDelete.BrandId = car.BrandId;
            carToDelete.ColorId = car.ColorId;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.ModelYear = car.ModelYear;
            carToDelete.Description = car.Description;
        }
    }
}
