using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Parol ən az 6 simvol ola bilər");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parol boş ola bilməz");

            RuleFor(x => x.About).NotEmpty().WithMessage("Haqqında boş ola bilməz");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad ən az 2 simvol ola bilər");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad ən çox 50 simvol ola bilər");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş ola bilməz");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş ola bilməz");
        }
    }
}
