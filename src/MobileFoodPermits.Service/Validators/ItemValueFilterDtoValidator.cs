using FluentValidation;
using MobileFoodPermits.Models.FoodPermitInfo;
using MobileFoodPermits.Service.Models.Filters;

namespace MobileFoodPermits.Service.Validators
{
    public class ItemValueFilterDtoValidator : AbstractValidator<ItemValueFilterDto>
    {
        public ItemValueFilterDtoValidator()
        {
            RuleFor(x => x.ShortName)
                .NotEmpty()
                .WithMessage("{PropertyName} is empty")
                .Must(shortName => ShortNameMappings.ShortNameToPropertyMapping.TryGetValue(shortName, out var _))
                .WithMessage($"ShortName is invalid, must be in [{string.Join(",", ShortNameMappings.ShortNameToPropertyMapping.Keys)}]");

            RuleFor(x => x.Values)
                .NotNull()
                .WithMessage("{PropertyName} is invalid or empty");
        }
    }
}
