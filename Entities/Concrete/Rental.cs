﻿using Core.Entity;
using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
   public class Rental : IEntity
    {
        [Key]
        public int RentId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime?  ReturnDate { get; set; }
    }
}
