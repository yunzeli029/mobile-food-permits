using System.Collections.Generic;

namespace MobileFoodPermits.Models.FoodPermitInfo
{
    public static class ShortNameMappings
    {
        public static Dictionary<string, string> ShortNameToPropertyMapping => new Dictionary<string, string>
        {
            { "APT", "Applicant" },
            { "FT", "FacilityType" },
            { "ADR", "Address" },
            { "FI", "FoodItems" },
            { "ST", "Status" }
        };
    }
}
