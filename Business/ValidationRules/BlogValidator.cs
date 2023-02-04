using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Title).MinimumLength(16).WithMessage("Başlıq ən az 16 simvol ola bilər");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Mövzu boş ola bilməz");
            RuleFor(x => x.Content).MinimumLength(35).WithMessage("Mövzu ən az 35 simvol ola bilər");
           
        }
    }
}
