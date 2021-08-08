using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using System.Collections.Generic;
using System.Linq;

namespace MobileFoodPermits.Extensions
{
    public static class FoodPermitCollectionExtensions
    {
        public static IEnumerable<FoodPermit> FilterItem(this FoodPermitCollection permitInfoCollection, IItemComparisonFilter filter)
        {
            return filter.Match(
                nameFilter => permitInfoCollection.FoodPermits.Where(nameFilter.IsMatch),
                geoFilter =>
                {
                    var circle = geoFilter.Point.CreateCircle(geoFilter.Radius);
                    return permitInfoCollection.STRtree.Query(circle.EnvelopeInternal);
                }
            );
        }
    }
}
