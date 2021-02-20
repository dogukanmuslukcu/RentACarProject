using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal// : ICarDal
    {
        //List<Car> _cars;
        //public InMemoryCarDal()
        //{
        //    _cars = new List<Car>
        //    {
        //         new Car{CarID=1,BrandId=1,ColorId=1, DailyPrice=4500000,ModelYear=2021, Description="1000 HP" },
        //         new Car{CarID=2,BrandId=1,ColorId=1, DailyPrice=45000,ModelYear=2021, Description="1050 HP" },
        //         new Car{CarID=3,BrandId=2,ColorId=1, DailyPrice=500000,ModelYear=2021, Description="800 HP" },
        //         new Car{CarID=4,BrandId=2,ColorId=1, DailyPrice=450085,ModelYear=2021, Description="9000 HP" },
        //    };
        //}
        //public void Add(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Delete(Car car)
        //{
        //    Car carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
        //    _cars.Remove(carToDelete);
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetByID(int carID)
        //{
        //    return _cars.Where(c=>c.CarID==carID).ToList();
        //}

        //public List<CarDetailsDto> GetCarDetails()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
        //    carToUpdate.CarID = car.CarID;
        //    carToUpdate.BrandId = car.BrandId;
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.DailyPrice = car.DailyPrice;
            
        //}
    }
}
