using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogName).NotEmpty().WithMessage("Blog title cannot be empty!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog content cannot be empty!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog image cannot be empty!");
            RuleFor(x => x.BlogName).MaximumLength(150).WithMessage("Data input less than 150 characters");
            RuleFor(x => x.BlogName).MinimumLength(5).WithMessage("Make more than 5 characters of data");

        }
    }
}
