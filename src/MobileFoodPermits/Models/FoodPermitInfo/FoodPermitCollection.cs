using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Strtree;
using System;
using System.Collections.Generic;

namespace MobileFoodPermits.Models.FoodPermitInfo
{
    /// <summary>
    /// A collection of food permits, it will store all the coordinates in a RTree <see cref="STRtree"> for fast searching.
    /// </summary>
    public class FoodPermitCollection
    {
        public FoodPermitCollection(DateTime timestamp, IEnumerable<FoodPermit> foodPermits)
        {
            Timestamp = timestamp;
            FoodPermits = foodPermits;
            STRtree = InitSTRtree(foodPermits);
        }

        public DateTime Timestamp { get; }

        public IEnumerable<FoodPermit> FoodPermits { get; } = new List<FoodPermit>();

        public STRtree<FoodPermit> STRtree { get; } = new STRtree<FoodPermit>();

        private static STRtree<FoodPermit> InitSTRtree(IEnumerable<FoodPermit> foodPermits)
        {
            var tree = new STRtree<FoodPermit>();

            foreach (var permit in foodPermits)
            {
                tree.Insert(new Envelope(permit.Location), permit);
            }

            return tree;
        }
    }
}
