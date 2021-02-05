using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal ;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine(" Kayıt eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Yeni kayıt işlemi başarısız oldu . Eksik yazdınız.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandID(int id)
        {
            return _carDal.GetAll(c => c.BrandID == id);
        }

        public List<Car> GetCarsByColorID(int id)
        {
            return _carDal.GetAll(c => c.ColorID == id);
        }
    }
}
