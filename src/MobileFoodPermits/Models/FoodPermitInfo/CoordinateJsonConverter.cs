using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;

namespace MobileFoodPermits.Models.FoodPermitInfo
{
    public class CoordinateJsonConverter : JsonConverter<Coordinate>
    {
        public override Coordinate ReadJson(JsonReader reader, Type objectType, Coordinate existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Coordinate value, JsonSerializer serializer)
        {
            writer.WriteValue($"({value.X}, {value.Y})");
        }
    }
}
