using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class ColorValidation : AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(cl => cl.ColorName.Length).GreaterThanOrEqualTo(3);
        }
    }
}
