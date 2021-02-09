
using Business.Concrete;
using DataAccess.Abstract;
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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarID+"  "+item.BrandName+"  "+item.ColorName+"  "+item.DailyPrice);
            }

           // ColorManagerTest(colorManager);
            //BrandManagerTest(brandManager)
            //CarManagerTest(carManager)

        }

        private static void ColorManagerTest(ColorManager colorManager)
        {
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void BrandManagerTest(BrandManager brandManager)
        {
            Console.WriteLine(brandManager.GetByID(5).BrandName);
        }

        private static void CarManagerTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }

            carManager.Add(new Car { });
            carManager.Delete(new Car { CarID = 7 })
            ; Console.WriteLine( carManager.GetById(5).DailyPrice ); 
            ;
        }
    }
}