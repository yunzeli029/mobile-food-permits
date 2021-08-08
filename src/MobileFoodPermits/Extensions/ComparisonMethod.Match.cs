using MobileFoodPermits.Models.Filters;
using System;

namespace MobileFoodPermits.Extensions
{
    public static class ComparisonMethodExtensions
    {
        public static TResult Match<TResult>(this ComparisonMethod comparison, Func<TResult> containsFunc, Func<TResult> equalsFunc)
        {
            return comparison switch
            {
                ComparisonMethod.Contains => containsFunc(),
                ComparisonMethod.Equals => equalsFunc(),
                _ => throw new InvalidOperationException($"Unhandled {nameof(comparison)} of type: {comparison}"),
            };
        }
    }
}
