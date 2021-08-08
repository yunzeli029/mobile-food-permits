using MobileFoodPermits.Models.FoodPermitInfo;
using System;
using System.Threading.Tasks;

namespace MobileFoodPermits.Models.Filters.Interfaces
{
    public interface IItemComparisonFilter : IEquatable<IItemComparisonFilter>
    {
        string ShortName { get; }

        TResult Match<TResult>(
            Func<IItemValueFilter, TResult> itemValueFunc,
            Func<IItemGeoFilter, TResult> itemGeoFunc);

        Task<TResult> MatchAsync<TResult>(
            Func<IItemValueFilter, Task<TResult>> itemValueFunc,
            Func<IItemGeoFilter, Task<TResult>> itemGeoFunc);

        bool IsMatch(FoodPermit info);
    }
}
