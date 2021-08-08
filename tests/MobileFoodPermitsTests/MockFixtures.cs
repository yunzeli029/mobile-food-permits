using MobileFoodPermits.Models.FoodPermitInfo;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace MobileFoodPermitsTests
{
    public static class MockFixtures
    {
        public static IEnumerable<Coordinate> GetOutBoundMockCoordiates() => new Coordinate[]
            {
                new Coordinate(37.494133,-121.895810),
                new Coordinate(37.637821,-121.807919),
            };

        public static IEnumerable<Coordinate> GetInBoundMockCoordiates() => new Coordinate[]
            {
                new Coordinate(37.78844615690132, -122.3986412420388),
                new Coordinate(37.502850,-122.357236),
            };

        public static Coordinate MockCentre = new Coordinate(37.78844616, -122.3986412);

        public static FoodPermitCollection MockFoodPermitCollection = new FoodPermitCollection(System.DateTime.Now, new FoodPermit[] {
                CreateMockPermit(37.78844615690132, -122.3986412420388, "Flavors of Africa", "APPROVED"),
                CreateMockPermit(37.494133, -121.895810, "MOMO INNOVATION LLC", "APPROVED"),
                CreateMockPermit(37.502850, -122.357236, "Senor Sisig", "REQUESTED"),
                CreateMockPermit(37.637821, -121.807919, "Natan's Catering", "EXPIRED"),
                CreateMockPermit(37.77110994, -122.38919, "Flavors of Test", "ISSUED"),
                CreateMockPermit(0, 0, "Golden Catering", "EXPIRED"),
            });

        private static FoodPermit CreateMockPermit(double x, double y, string applicant, string status)
        {
            var permit = new FoodPermit()
            {
                Latitude = x,
                Longitude = y,
                Applicant = applicant,
                Status = status
            };

            return permit;

        }
    }
}
