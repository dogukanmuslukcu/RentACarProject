using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public class BrandValidatior : AbstractValidator<Brand>
    {
        public BrandValidatior()
        {
            RuleFor(b => b.BrandName.Length).GreaterThanOrEqualTo(3);
        }
    }
}
