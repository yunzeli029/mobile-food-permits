using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using System;

namespace MobileFoodPermits.Extensions
{
    public static partial class CoordinateExtensions
    {
        // unit - meter
        private static double R_EARTH = 6371000;
        private static double P_EARTH = 2 * Math.PI * R_EARTH;
        private static double parseYLengthToDegree(double length)
        {
            //convert length to degree
            double yDegree = length / P_EARTH * 360;
            return yDegree;
        }

        // Unit of radius is km while the unit of coordinate is meter
        public static Polygon CreateCircle(this Coordinate coordinate, int radius)
        {
            var gsf = new GeometricShapeFactory()
            {
                Centre = coordinate,
                Size = parseYLengthToDegree(radius * 1000) * 2,
            };

            return gsf.CreateCircle();
        }
    }
}
