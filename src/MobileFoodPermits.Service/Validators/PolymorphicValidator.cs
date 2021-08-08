using FluentValidation;

namespace MobileFoodPermits.Service.Validators
{
    /// <summary>
    /// Allows validation of derived classes of a base class with distinct validation logic
    /// </summary>
    /// <typeparam name="TBase"></typeparam>
    public class PolymorphicValidator<TBase> : AbstractValidator<TBase>
    {
        /// <summary>
        /// Adds validation behaviour for the subclass validator
        /// </summary>
        /// <typeparam name="TDerived"></typeparam>
        /// <param name="derivedValidator"></param>
        /// <returns></returns>
        public PolymorphicValidator<TBase> Add<TDerived>(IValidator<TDerived> derivedValidator)
            where TDerived : TBase
        {
            When(
                model => model is TDerived,
                () =>
                {
                    RuleFor(model => (TDerived)model)
                        .SetValidator(derivedValidator);
                });

            return this;
        }
    }
}
