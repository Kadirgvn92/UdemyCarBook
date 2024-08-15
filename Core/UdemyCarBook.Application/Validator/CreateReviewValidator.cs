using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validator;
public class CreateReviewValidator :AbstractValidator<CreateReviewCommand>
{
    public CreateReviewValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Lütfen Müşteri adını boş geçmeyiniz.")
            .MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
        RuleFor(x => x.RatingValue)
            .NotEmpty().WithMessage("Lütfen değerlendirme kısmını boş geçmeyiniz");
        RuleFor(x => x.Comment)
               .NotEmpty().WithMessage("Lütfen yorum kısmını boş geçmeyiniz")
               .MinimumLength(50).WithMessage("Lütfen en az 50 karakter girişi yapınız.");



	}
}
