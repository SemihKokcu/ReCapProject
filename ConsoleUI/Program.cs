using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //GenelTest();
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in colorManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
               // Console.WriteLine(car.CarName +"/"+car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice);
            }

        }

        private static void GenelTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(car2);

            //Color color = new Color { Id = 6, Name = "Beyaz" };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(color);

            // Brand brand = new Brand { Id = 6, Name = "BMW" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(brand);

            foreach (var car in brandManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
            //Console.WriteLine(colorManager.GetColor(3).Name);
        }

        private static void CarTest()
        {
            //Car car1 = new Car { Id = 3, Name = "Hyundai", BrandId = 2, ColorId = 2, ModelYear = 2000, DailyPrice = 300, Description = "temiz" };
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(car1);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
        }
    }

   
    
}
