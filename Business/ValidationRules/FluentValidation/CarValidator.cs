using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description.Length).GreaterThanOrEqualTo(3);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(4);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            
        }
    }
}
