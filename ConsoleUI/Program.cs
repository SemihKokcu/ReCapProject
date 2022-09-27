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
            Car car1 = new Car { Id=3, Name = "Hyundai", BrandId = 2, ColorId = 2, ModelYear = 2000, DailyPrice = 300, Description = "temiz" };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }
        }
    }

   
    
}
