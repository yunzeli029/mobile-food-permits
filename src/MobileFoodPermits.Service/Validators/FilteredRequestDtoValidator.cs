using FluentValidation;
using MobileFoodPermits.Service.Models;
using MobileFoodPermits.Service.Models.Filters;

namespace MobileFoodPermits.Service.Validators
{
    public sealed class FilteredRequestDtoValidator : AbstractValidator<FilteredRequestDto>
    {
        public FilteredRequestDtoValidator(IValidator<ItemComparisonFilterDto> filterValidator)
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Filter)
                .NotEmpty()
                .SetValidator(filterValidator);
        }
    }
}
