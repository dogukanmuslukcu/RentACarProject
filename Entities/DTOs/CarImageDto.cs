﻿using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
     public class CarImageDto:IDto
    {

        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
