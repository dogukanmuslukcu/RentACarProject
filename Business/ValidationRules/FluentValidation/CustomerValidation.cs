using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(ct => ct.Email).NotEmpty();
            RuleFor(ct => ct.FirstName).NotEmpty();
            RuleFor(ct => ct.LastName).NotEmpty();
            RuleFor(ct => ct.CompanyName).NotEmpty();
            RuleFor(ct => ct.Password).NotEmpty();
            RuleFor(ct => ct.Password.Length).GreaterThanOrEqualTo(8);
            RuleFor(ct => ct.Email).Must(ContainSpecificCharacter1).WithMessage("email adresi @ içermelidir.");
            RuleFor(ct => ct.Password).Must(ContainSpecificCharacters).WithMessage("şifreniz en az bir rakam veyahut ( ? & @ # ) dan birini içermelidir.");
        }

        private bool ContainSpecificCharacters(string arg)
        {
            string[] SpecificCharacters = new string[] { "0","1","2","3","4","5","6","7","8","9","*","#","@","&","&","?" };
            bool check = false;
            for (int i = 0; i < SpecificCharacters.Length; i++)
            {
                if (arg.Contains(SpecificCharacters[i]))
                {
                    check = true;
                }
               
            }
            if (check)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private bool ContainSpecificCharacter1(string arg)
        {
            return arg.Contains("@");
        }
    }
}
