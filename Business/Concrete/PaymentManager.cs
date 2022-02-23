using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Payment(CreditCard creditCard)
        {
            return new SuccessResult("Ödeme Başarılı!");
        }
    }
}
