using FluentValidation;
using LIBRARYMVC_TEST.Models.ViewModels;

namespace LIBRARYMVC_TEST.Validator
{
    public class BookValidator : AbstractValidator<BookVM>
    {
        public BookValidator()
        {
            RuleFor(x => x.Book.Title)
                .NotNull().WithMessage("El titulo es obligatorio")
                .MaximumLength(60).WithMessage("El titulo debe tener maximo 60 caracteres");

            RuleFor(x => x.Book.AuthorId)
                .NotNull().WithMessage("Seleccione un autor");
        }
    }
}
