using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
     public class CreditCard :IEntity
    {
        public string NameAndSurname { get; set; }
        public long CartNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }

        public int Cvc { get; set; }

    }
}
