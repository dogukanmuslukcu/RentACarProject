using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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


        public void Add(Car car)
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

       

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç silinmiştir.");
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araç güncellenmiştir.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }


        public Car GetById(int id) 
        {
            return _carDal.Get(c=>c.CarID==id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
