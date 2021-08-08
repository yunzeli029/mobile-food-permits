using JsonSubTypes;
using Newtonsoft.Json;
using System;
using MobileFoodPermits.Models.Filters;

namespace MobileFoodPermits.Service.Models.Filters
{
    /// <summary>
    /// A DTO object of <see cref="ItemComparisonFilter">
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(ItemGeoFilterDto), nameof(ItemGeoFilterDto.Latitude))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(ItemValueFilterDto), nameof(ItemValueFilterDto.Values))]
    public abstract class ItemComparisonFilterDto : IEquatable<ItemComparisonFilterDto>
    {
        public ItemComparisonFilterDto(string shortName)
        {
            ShortName = shortName;
        }

        public string ShortName { get; }

        public virtual bool Equals(ItemComparisonFilterDto other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(ShortName, other.ShortName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is ItemComparisonFilterDto other
                && Equals(other);
        }

        public override int GetHashCode()
        {
            return (ShortName?.GetHashCode() ?? 0) * 397;
        }
    }
}
