using FluentValidation;
using MobileFoodPermits.Service.Models.Filters;

namespace MobileFoodPermits.Service.Validators
{
    public class ItemComparisonFilterDtoValidator : PolymorphicValidator<ItemComparisonFilterDto>
    {
        public ItemComparisonFilterDtoValidator()
        {
            RuleFor(filter => filter)
                .NotEmpty()
                .WithMessage("{PropertyName} is empty");

            Add(new ItemValueFilterDtoValidator());

            Add(new ItemGeoFilterDtoValidator());
        }
    }
}

