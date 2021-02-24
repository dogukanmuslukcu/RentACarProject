using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class ColorValidatior : AbstractValidator<Color>
    {
        public ColorValidatior()
        {
            RuleFor(cl => cl.ColorName.Length).GreaterThanOrEqualTo(3);
        }
    }
}
