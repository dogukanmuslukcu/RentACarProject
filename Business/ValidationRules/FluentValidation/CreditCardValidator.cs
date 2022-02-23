using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
     public class CreditCardValidator :AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(cc => cc.NameAndSurname).NotEmpty().WithMessage("İsim Soyisim boş olamaz");
            RuleFor(cc => cc.CartNumber).NotEmpty().WithMessage("Kredi Kartı Numarası boş olamaz");
            RuleFor(cc => cc.ExpMonth).NotEmpty().WithMessage("Son kullanma tarihinin Ay kısmı  boş olamaz"); 
            RuleFor(cc => cc.ExpYear).NotEmpty().WithMessage("Son kullanma tarihinin Yıl kısmı boş olamaz"); 
            RuleFor(cc => cc.Cvc).NotEmpty().WithMessage("cvc boş olamaz");

            RuleFor(cc => cc.CartNumber).Must(x => x.ToString().Length == 16).WithMessage("Kredi Kartı 16 hane olmalıdır");
            RuleFor(cc => cc.ExpMonth).Must(x => x.ToString().Length == 2).WithMessage("Son kullanma tarihinin ay kısmı 2  hane olmalıdır");
            RuleFor(cc => cc.ExpYear).Must(x => x.ToString().Length == 4).WithMessage("Son kullanma tarihinin yıl kısmı 4 hane olmalıdır");
            RuleFor(cc => cc.Cvc).Must(x => x.ToString().Length == 3).WithMessage("Cvc kodu 3 hane olmalıdır");


        }
        
    }
}
