using System.Collections.Generic;

namespace MobileFoodPermits.Models.Filters.Interfaces
{
    public interface IItemValueFilter : IItemComparisonFilter
    {
        HashSet<string> Values { get; }
    }
}
