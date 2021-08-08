using MobileFoodPermits.Extensions;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Strtree;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace MobileFoodPermitsTests
{
    public class NetTopologySuiteTests
    {
        private readonly STRtree<Coordinate> _gpsSTRtree;

        public NetTopologySuiteTests()
        {
            _gpsSTRtree = new STRtree<Coordinate>();
        }

        [Fact]
        public void GivenValidCoordiateAndRadiu_Should_ReturnsAListOfValidCoordiates()
        {           
            var coordinate = MockFixtures.MockCentre;

            var circle = coordinate.CreateCircle(50);           

            var coordiates = MockFixtures.GetInBoundMockCoordiates()
                .Concat(MockFixtures.GetOutBoundMockCoordiates());

            foreach (var cd in coordiates)
            {
                _gpsSTRtree.Insert(new Envelope(cd), cd);
            }

            var list = _gpsSTRtree.Query(circle.EnvelopeInternal);
            Assert.Equal(2, list.Count());
        }
    }
}
