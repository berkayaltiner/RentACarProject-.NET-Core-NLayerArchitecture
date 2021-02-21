using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("ADDED");
            Console.WriteLine("-----------");

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
            Console.WriteLine("GetById");
            Console.WriteLine("-----------");

            foreach (var car in carManager.GetById(7))// GetById returns a List type. That's why we should use foreach to visit all object in the List.
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
