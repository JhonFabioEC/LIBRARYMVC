using FluentValidation;
using LIBRARYMVC_TEST.Models;

namespace LIBRARYMVC_TEST.Validator
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre es obligatorio")
                .MaximumLength(60).WithMessage("El nombre debe tener maximo 60 caracteres");
        }
    }
}
