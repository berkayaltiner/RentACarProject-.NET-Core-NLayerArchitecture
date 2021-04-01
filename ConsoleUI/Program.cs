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
            //BrandTest();
            //ColorTest();
            //CarTest();
            RentalTest();
            

        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            /*
             
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            var result = rentalManager.Add(new Rental { CarId = 10, CustomerId = 6, RentDate = date, ReturnDate = null });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
             */

            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach(var item in result.Data)
                {
                    Console.WriteLine(item.BrandName + " / " + item.CarName + " / " + item.ColorName + " / " + item.CustomerName + " / " + item.CustomerLastName + " / " +
                                      item.CustomerCompanyName + " / "+ item.RentDate + " - " + item.ReturnDate + " / " + item.DailyPrice);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("-----------");
            Console.WriteLine("BRAND ADDED");
            Console.WriteLine("-----------");

            //brandManager.Add(new Brand { BrandId = 1, BrandName = "Renault" });
            //brandManager.Add(new Brand { BrandId = 2, BrandName = "Toyota" });
            //brandManager.Add(new Brand { BrandId = 3, BrandName = "Volkswagen" });
            //brandManager.Add(new Brand { BrandId = 4, BrandName = "Ford" });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("BRAND UPDATED");
            Console.WriteLine("-----------");

            //brandManager.Update(new Brand { BrandId = 4, BrandName = "Honda" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("BRAND DELETED");
            Console.WriteLine("-----------");

            //brandManager.Delete(new Brand { BrandId = 4, BrandName = "Honda" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("BRAND GetById");
            Console.WriteLine("-----------");

            var tempBrand = brandManager.GetById(2).Data;
            Console.WriteLine(tempBrand.BrandName);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("CAR UPDATED");
            Console.WriteLine("-----------");

            //carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 3, ModelYear = 2019, DailyPrice = 150, CarName = "Clio", Description = "Renault Clio Otomatik Siyah 2019" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("CAR DELETED");
            Console.WriteLine("-----------");

            //carManager.Delete(new Car { Id = 1, BrandId = 1, ColorId = 3, ModelYear = 2019, DailyPrice = 150, CarName = "Clio", Description = "Renault Clio Otomatik Siyah 2019" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("CAR GetByBrandId");
            Console.WriteLine("-----------");

            foreach (var car in carManager.GetCarsByBrandId(3).Data)// GetById returns a List type. That's why we should use foreach to visit all object in the List.
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("CAR GetByColorId");
            Console.WriteLine("-----------");

            foreach (var car in carManager.GetCarsByColorId(3).Data)// GetById returns a List type. That's why we should use foreach to visit all object in the List.
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("CAR DETAILS");
            Console.WriteLine("-----------");
            foreach (var car in carManager.GetCarDetailDtos().Data) //Joined tables.
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice); 
            }

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("-----------");
            Console.WriteLine("COLOR ADDED");
            Console.WriteLine("-----------");

            //colorManager.Add(new Color { ColorId = 1, ColorName = "Beyaz" });
            //colorManager.Add(new Color { ColorId = 2, ColorName = "Gri" });
            //colorManager.Add(new Color { ColorId = 3, ColorName = "Siyah" });
            //colorManager.Add(new Color { ColorId = 4, ColorName = "Mavi" });

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("COLOR UPDATED");
            Console.WriteLine("-----------");

            //colorManager.Update(new Color { ColorId = 4, ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("COLOR DELETED");
            Console.WriteLine("-----------");

            //colorManager.Delete(new Color { ColorId = 4, ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("COLOR GetById");
            Console.WriteLine("-----------");

            var tempColor = colorManager.GetById(2).Data;
            Console.WriteLine(tempColor.ColorName);
        }
    }

        
}


