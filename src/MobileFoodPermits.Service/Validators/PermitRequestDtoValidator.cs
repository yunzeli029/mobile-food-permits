using FluentValidation;
using MobileFoodPermitAPI.Models;

namespace MobileFoodPermitAPI.Validators
{
    public sealed class PermitRequestDtoValidator : AbstractValidator<PermitRequestDto>
    {
        public PermitRequestDtoValidator()
        {
            RuleFor(x => x);
        }
    }
}
