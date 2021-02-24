using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class UserValidatior : AbstractValidator<User>
    {
        public UserValidatior()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(8);
            RuleFor(u => u.Password).Must(ContainSpecificCharacters).WithMessage("şifreniz en az bir rakam veyahut ( ? & @ # ) dan birini içermelidir.");
            RuleFor(u => u.Email).Must(ContainSpecificCharacter1).WithMessage("email adresi @ içermelidir.");
        }
        private bool ContainSpecificCharacters(string arg)
        {
            string[] SpecificCharacters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "*", "#", "@", "&", "&", "?" };
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
