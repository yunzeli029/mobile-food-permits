using MobileFoodPermits.Extensions;
using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileFoodPermits.Models.Filters
{
    /// <summary>
    /// A filter to filter FoodPermit by the value of its properties.
    /// All the values will be converted to string format.
    /// Then based on the comparison method, it will check whether the value contains / equals the requested pattern
    /// </summary>
    public class ItemValueFilter : ItemComparisonFilter, IItemValueFilter
    {
        private readonly Func<FoodPermit, bool> _predicate;
        public ItemValueFilter(string shortName, IEnumerable<string> values, ComparisonMethod comparison = ComparisonMethod.Contains) : base(shortName)
        {
            Values = values.ToHashSet();
            _predicate = GetPredicate(shortName, Values, comparison);
            Comparison = comparison;
        }

        public HashSet<string> Values { get; }

        public ComparisonMethod Comparison { get; }

        public override bool Equals(IItemComparisonFilter other)
        {
            return base.Equals(other)
                && other is IItemValueFilter itemNameFilter
                && Values.SetEquals(itemNameFilter.Values);
        }

        public override int GetHashCode()
        {
            var hashCode = base.GetHashCode();

            hashCode = hashCode * 397 ^ Values.GetHashCode();

            return hashCode;
        }

        public override bool IsMatch(FoodPermit info) => _predicate(info);

        public override TResult Match<TResult>(
            Func<IItemValueFilter, TResult> itemValueFunc,
            Func<IItemGeoFilter, TResult> itemGeoFunc)
        {
            return itemValueFunc(this);
        }

        public override Task<TResult> MatchAsync<TResult>(
            Func<IItemValueFilter, Task<TResult>> itemValueFunc,
            Func<IItemGeoFilter, Task<TResult>> itemGeoFunc)
        {
            return itemValueFunc(this);
        }

        private static Func<FoodPermit, bool> GetPredicate(string shortName, HashSet<string> patterns, ComparisonMethod comparison)
        {
            bool comparator(FoodPermit item, string pattern)
            {
                var patternUpper = pattern.ToUpper();
                var property = ShortNameMappings.ShortNameToPropertyMapping.GetValueOrDefault(shortName, string.Empty);
                var value = item.GetType().GetProperty(property)?.GetValue(item, null)?.ToString().ToUpper() ?? string.Empty;

                return comparison.Match(
                    () => value.Contains(patternUpper),
                    () => value.Equals(patternUpper));
            }

            return item => patterns.Count > 0 ? patterns.Any(pattern => comparator(item, pattern)) : true;
        }
    }
}
