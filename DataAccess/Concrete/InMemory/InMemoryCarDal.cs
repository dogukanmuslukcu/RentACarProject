using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                 new Car{CarID=1,BrandID=1,ColorID=1, DailyPrice=4500000,ModelYear=2021, Description="1000 HP" },
                 new Car{CarID=2,BrandID=1,ColorID=1, DailyPrice=45000,ModelYear=2021, Description="1050 HP" },
                 new Car{CarID=3,BrandID=2,ColorID=1, DailyPrice=500000,ModelYear=2021, Description="800 HP" },
                 new Car{CarID=4,BrandID=2,ColorID=1, DailyPrice=450085,ModelYear=2021, Description="9000 HP" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByID(int carID)
        {
            return _cars.Where(c=>c.CarID==carID).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
            carToUpdate.CarID = car.CarID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            
        }
    }
}
