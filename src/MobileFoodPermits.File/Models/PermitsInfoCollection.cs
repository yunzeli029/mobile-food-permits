using System;
using System.Collections.Generic;

namespace MobileFoodPermits.File.Models
{
    public class PermitsInfoCollection
    {
        public PermitsInfoCollection(DateTime timestamp, IEnumerable<PermitInfo> permitInfos)
        {
            Timestamp = timestamp;
            PermitInfos = permitInfos;
        }

        public DateTime Timestamp { get; }

        public IEnumerable<PermitInfo> PermitInfos { get; } = new List<PermitInfo>();
    }
}
