using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Name field cannot be blank");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail field cannot be blank");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password field cannot be blank");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Your password must contain at least one letter and one number!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("You must enter a minimum of 2 characters.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("You must enter a maximum of 50 characters.");


        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }

    }
}
