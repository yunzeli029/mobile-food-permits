using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using System;
using System.Threading.Tasks;

namespace MobileFoodPermits.Models.Filters
{
    public abstract class ItemComparisonFilter : IItemComparisonFilter
    {
        protected ItemComparisonFilter(string shortName)
        {
            ShortName = shortName;
        }

        public string ShortName { get; }

        public virtual bool Equals(IItemComparisonFilter other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ShortName.Equals(other.ShortName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is IItemComparisonFilter other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ShortName.GetHashCode() * 397;
        }

        public abstract bool IsMatch(FoodPermit info);

        public abstract TResult Match<TResult>(
            Func<IItemValueFilter, TResult> itemValueFunc,
            Func<IItemGeoFilter, TResult> itemGeoFunc);

        public abstract Task<TResult> MatchAsync<TResult>(
            Func<IItemValueFilter, Task<TResult>> itemValueFunc,
            Func<IItemGeoFilter, Task<TResult>> itemGeoFunc);
    }
}
