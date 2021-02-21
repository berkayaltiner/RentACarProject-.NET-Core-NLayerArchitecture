using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
