using MobileFoodPermits.Extensions;
using MobileFoodPermits.Models.Filters;
using MobileFoodPermits.Models.FoodPermitInfo;
using NetTopologySuite.Geometries;
using System.Linq;
using Xunit;
using static MobileFoodPermitsTests.MockFixtures;
namespace MobileFoodPermitsTests
{
    /// <summary>
    /// Filter tests to test whether the filters could return correct result
    /// </summary>
    public class FilterTests
    {
        private readonly FoodPermitCollection _foodPermitCollection;

        public FilterTests()
        {
            _foodPermitCollection = MockFoodPermitCollection;
        }

        [Theory]
        [InlineData("APT", new[] { "Flavors" }, 2)]
        [InlineData("APT", new[] { "MOMO", "senor" }, 2)]
        [InlineData("ST", new[] { "REQUESTED", "APPROVED" }, 3)]
        [InlineData("ST", new[] { "EXPIRED" }, 2)]
        public void GivenValidValueFilter_FilterItem_Should_ReturnsCorrectResult(string shortName, string[] patterns, int expected)
        {
            var actual = _foodPermitCollection.FilterItem(new ItemValueFilter(shortName, patterns));

            Assert.Equal(expected, actual.Count());
        }

        [Theory]
        [InlineData("APT", new[] { "MOMO1xa"}, 0)]
        [InlineData("ST", new[] { "REQUESTED2"}, 0)]
        public void GivenInValidValueFilter_FilterItem_Should_ReturnsEmptyResult(string shortName, string[] patterns, int expected)
        {
            var actual = _foodPermitCollection.FilterItem(new ItemValueFilter(shortName, patterns));

            Assert.Equal(expected, actual.Count());
        }

        [Theory]
        [InlineData("APT", new[] { "Flavors of Africa" }, 1)]
        [InlineData("ST", new[] { "REQUESTED", "APPROVED" }, 3)]
        public void GivenValidValueFilterWithEqualComparisonMethod_FilterItem_Should_ReturnsCorrectResult(string shortName, string[] patterns, int expected)
        {
            var actual = _foodPermitCollection.FilterItem(new ItemValueFilter(shortName, patterns, ComparisonMethod.Equals));

            Assert.Equal(expected, actual.Count());
        }


        [Theory]
        [InlineData("APT", new[] { "Flavors" }, 0)]
        [InlineData("ST", new[] { "MOMO", "senor" }, 0)]
        public void GivenInValidValueFilterWithEqualComparisonMethod_FilterItem_Should_ReturnsEmptyResult(string shortName, string[] patterns, int expected)
        {
            var actual = _foodPermitCollection.FilterItem(new ItemValueFilter(shortName, patterns, ComparisonMethod.Equals));

            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public void GivenValidGeoFilter_FilterItem_Should_ReturnsCorrectResult()
        {
            var actual = _foodPermitCollection.FilterItem(new ItemGeoFilter(MockCentre, 50));

            Assert.Equal(3, actual.Count());
        }


        [Fact]
        public void GivenInValidGeoFilter_FilterItem_Should_ReturnsEmptyResult()
        {
            var actual = _foodPermitCollection.FilterItem(new ItemGeoFilter(new Coordinate(45.344334, -136.622794), 50));

            Assert.Empty(actual);
        }


    }
}
