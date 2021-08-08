using FluentValidation;
using MobileFoodPermits.Service.Models.Filters;

namespace MobileFoodPermits.Service.Validators
{
    public class ItemGeoFilterDtoValidator : AbstractValidator<ItemGeoFilterDto>
    {
        public ItemGeoFilterDtoValidator()
        {
            RuleFor(filter => filter.Latitude)
                .Must(val => val >= -90 && val <= 90)
                .WithMessage("{PropertyName} must be between -90 and 90");

            RuleFor(filter => filter.Longitude)
                .Must(val => val >= -180 && val <= 180)
                .WithMessage("{PropertyName} must be between -180 and 180");

            RuleFor(filter => filter.Radius)
                .Must(val => val >= 0 && val <= 100)
                .WithMessage("{PropertyName} must be between 0 and 100 km");
        }
    }
}
