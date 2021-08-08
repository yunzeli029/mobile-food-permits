using MobileFoodPermits.Service.Models.Filters;
using System;

namespace MobileFoodPermits.Service.Extensions
{
    public static partial class ItemComparisonFilterDtoExtensions
    {
        public static TResult Match<TResult>(this ItemComparisonFilterDto filter, Func<ItemValueFilterDto, TResult> itemValueFilterFunc, Func<ItemGeoFilterDto, TResult> itemGeoFilterFunc)
        {
            return filter switch
            {
                ItemValueFilterDto itemValueFilterDto => itemValueFilterFunc(itemValueFilterDto),
                ItemGeoFilterDto itemGeoFilterDto => itemGeoFilterFunc(itemGeoFilterDto),
                _ => throw new InvalidOperationException($"Unhandled {nameof(filter)} of type: {filter?.GetType()}"),
            };
        }
    }
}
