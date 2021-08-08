using MobileFoodPermits.Models.Filters;
using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Service.Models.Filters;
using NetTopologySuite.Geometries;

namespace MobileFoodPermits.Service.Extensions
{
    public static partial class ItemComparisonFilterDtoExtensions
    {
        public static IItemComparisonFilter Convert(this ItemComparisonFilterDto filter)
        {
            return filter.Match<IItemComparisonFilter>(
                itemValueFilter =>
                {
                    return new ItemValueFilter(itemValueFilter.ShortName, itemValueFilter.Values, itemValueFilter.Comparison);
                },
                itemGeoFilter =>
                {
                    var coordinate = new Coordinate(itemGeoFilter.Latitude, itemGeoFilter.Longitude);
                    return new ItemGeoFilter(coordinate, itemGeoFilter.Radius);
                });
        }
    }
}
