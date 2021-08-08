using CsvHelper.Configuration.Attributes;
using System;

namespace MobileFoodPermits.File.Models
{
    public struct PermitInfo
    {
        public int LocationId { get; set; }
        public string Applicant { get; set; }
        public string FacilityType { get; set; }
        public long CNN { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public long BlockLot { get; set; }
        public int Block { get; set; }
        public int lot { get; set; }
        public string Permit { get; set; }
        public string Status { get; set; }
        public string FoodItems { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Schedule { get; set; }
        public DateTime Approved { get; set; }
        public int Received { get; set; }
        public bool PriorPermit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Location { get; set; }
    }
}
