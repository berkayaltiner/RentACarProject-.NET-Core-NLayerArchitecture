using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal ());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("ADDED");
            Console.WriteLine("-----------");
            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2017, DailyPrice = 120, Description = "Renault Clio Otomatik Beyaz 2017" });
            carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 3, ModelYear = 2019, DailyPrice = 120, Description = "Renault Clio Manuel Siyah 2019" });
            carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2015, DailyPrice = 150, Description = "Toyota Corolla Manuel Beyaz 2015" });
            carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 150, Description = "Toyota Corolla Otomatik Gri 2020" });
            carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 3, ModelYear = 2017, DailyPrice = 175, Description = "Volkswagen Passat Manuel Siyah 2017" });
            carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2019, DailyPrice = 175, Description = "Volkswagen Passat Otomatik Gri 2019" });
            carManager.Add(new Car {Id=7,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=180,Description="Volkswagen Passat Otomatik Beyaz 2020" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("UPDATED");
            Console.WriteLine("-----------");

            carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 3, ModelYear = 2019, DailyPrice = 150, Description = "Renault Clio Otomatik Siyah 2019" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("DELETED");
            Console.WriteLine("-----------");

            carManager.Delete(new Car { Id = 1, BrandId = 1, ColorId = 3, ModelYear = 2019, DailyPrice = 150, Description = "Renault Clio Otomatik Siyah 2019" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("GetByBrandId");
            Console.WriteLine("-----------");

            foreach (var car in carManager.GetCarsByBrandId(3))// GetById returns a List type. That's why we should use foreach to visit all object in the List.
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("GetByColorId");
            Console.WriteLine("-----------");

            foreach (var car in carManager.GetCarsByColorId(3))// GetById returns a List type. That's why we should use foreach to visit all object in the List.
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
