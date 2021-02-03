
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
                Console.WriteLine(car.CarID);
            }
            InMemoryCarDal ınMemoryCarDal = new InMemoryCarDal();
            ınMemoryCarDal.Add(new Car { });
        }
    }
}