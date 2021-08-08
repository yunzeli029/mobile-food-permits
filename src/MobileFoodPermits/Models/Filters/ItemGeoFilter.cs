using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using NetTopologySuite.Geometries;
using System;
using System.Threading.Tasks;

namespace MobileFoodPermits.Models.Filters
{
    /// <summary>
    /// Filter the collection result by checking whether the Circle created by the ItemGeoFilter intersects with the points.
    /// </summary>
    public class ItemGeoFilter : ItemComparisonFilter, IItemGeoFilter
    {
        public ItemGeoFilter(Coordinate point, int radius) : base("Geo")
        {
            Point = point;
            Radius = radius;
        }

        public Coordinate Point { get; }

        public int Radius { get; }

        public override bool Equals(IItemComparisonFilter other)
        {
            return base.Equals(other)
                && other is IItemGeoFilter itemGeoFilter
                && Point.Equals(itemGeoFilter.Point)
                && Radius == itemGeoFilter.Radius;
        }

        public override int GetHashCode()
        {
            var hashCode = base.GetHashCode();

            hashCode = hashCode * 397 ^ Point.GetHashCode();
            hashCode = hashCode * 397 ^ Radius.GetHashCode();

            return hashCode;
        }

        public override bool IsMatch(FoodPermit info) => throw new NotImplementedException();

        public override TResult Match<TResult>(
            Func<IItemValueFilter, TResult> itemValueFunc,
            Func<IItemGeoFilter, TResult> itemGeoFunc)
        {
            return itemGeoFunc(this);
        }

        public override Task<TResult> MatchAsync<TResult>(
            Func<IItemValueFilter, Task<TResult>> itemValueFunc,
            Func<IItemGeoFilter, Task<TResult>> itemGeoFunc)
        {
            return itemGeoFunc(this);
        }
    }
}
