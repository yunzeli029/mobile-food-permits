using NetTopologySuite.Geometries;

namespace MobileFoodPermits.Models.Filters.Interfaces
{
    public interface IItemGeoFilter : IItemComparisonFilter
    {
        public Coordinate Point { get; }

        public int Radius { get; }
    }
}
