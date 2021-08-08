using MobileFoodPermits.Models.Filters;
using System.Collections.Generic;
using System.Linq;

namespace MobileFoodPermits.Service.Models.Filters
{
    /// <summary>
    /// A DTO object of <see cref="ItemValueFilter">
    /// </summary>
    public class ItemValueFilterDto : ItemComparisonFilterDto
    {
        public ItemValueFilterDto(
            string shortName, 
            IEnumerable<string> values, 
            ComparisonMethod comparison = default) : base(shortName)
        {
            Values = values?.ToHashSet() ?? new HashSet<string>();
            Comparison = comparison;
        }

        public HashSet<string> Values { get; }

        public ComparisonMethod Comparison { get; }

        public override bool Equals(ItemComparisonFilterDto other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && other is ItemValueFilterDto itemNameFilterOther
                && Values.SetEquals(itemNameFilterOther.Values)
                && Comparison == itemNameFilterOther.Comparison;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ Values.GetHashCode();
                hashCode = (hashCode * 397) ^ Comparison.GetHashCode();
                return hashCode;
            }
        }
    }
}
