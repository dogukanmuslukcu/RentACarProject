using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer :User, IEntity
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
    }
}
