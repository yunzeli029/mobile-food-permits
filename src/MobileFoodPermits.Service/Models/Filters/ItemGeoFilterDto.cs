using MobileFoodPermits.Models.Filters;

namespace MobileFoodPermits.Service.Models.Filters
{
    /// <summary>
    /// A DTO object of <see cref="ItemGeoFilter">
    /// </summary>
    public class ItemGeoFilterDto : ItemComparisonFilterDto
    {
        public ItemGeoFilterDto(double latitude, double longitude, int radius) : base("Geo")
        {
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }

        public double Latitude { get; }

        public double Longitude { get; }

        public int Radius { get; }

        public override bool Equals(ItemComparisonFilterDto other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && other is ItemGeoFilterDto itemGeoFilterOther
                && Latitude == itemGeoFilterOther.Latitude
                && Longitude == itemGeoFilterOther.Longitude
                && Radius == itemGeoFilterOther.Radius;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Latitude.GetHashCode());
                hashCode = (hashCode * 397) ^ (Longitude.GetHashCode());
                hashCode = (hashCode * 397) ^ (Radius.GetHashCode());

                return hashCode;
            }
        }
    }
}
