using NetTopologySuite.Geometries;
using System;

namespace MobileFoodPermits.Models.FoodPermitInfo
{
    public class FoodPermit
    {
        public int? LocationId { get; set; }
        public string Applicant { get; set; }
        public string FacilityType { get; set; }
        public long? CNN { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string BlockLot { get; set; }
        public string Block { get; set; }
        public string lot { get; set; }
        public string Permit { get; set; }
        public string Status { get; set; }
        public string FoodItems { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Schedule { get; set; }
        public DateTime? Approved { get; set; }
        public int? Received { get; set; }
        public bool? PriorPermit { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Coordinate Location
        {
            get
            {
                if (Latitude != null && Longitude != null)
                {
                    return new Coordinate((double)Latitude, (double)Longitude);
                }

                return new Coordinate();
            }
        }
    }
}
