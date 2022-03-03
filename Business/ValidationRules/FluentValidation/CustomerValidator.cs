using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        { 
            RuleFor(ct => ct.CompanyName).NotEmpty();
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

        private bool ContainSpecificEmailCharacter(string arg)
        {
            return arg.Contains("@");
        }
    }
}
