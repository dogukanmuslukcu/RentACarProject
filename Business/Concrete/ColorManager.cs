using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorService;

        public ColorManager(IColorDal colorService)
        {
            _colorService = colorService;
        }

        public void Add(Color color)
        {
            _colorService.Add(color);
            Console.WriteLine("Renk eklenmiştir.");
        }

        public void Delete(Color color)
        {
            _colorService.Delete(color);
            Console.WriteLine("Renk silinmiştir");
        }

        public List<Color> GetAll()
        {
            return _colorService.GetAll();
        }

        public Color GetByID(int id)
        {
            return _colorService.Get(c => c.ColorID == id);
        }

        public void Update(Color color)
        {
            _colorService.Update(color);
            Console.WriteLine("Renk güncellendi.");

        }
    }
}
