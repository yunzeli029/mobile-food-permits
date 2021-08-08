using Microsoft.Extensions.DependencyInjection;
using MobileFoodPermits.File;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.File.Services;
using MobileFoodPermits.File.Services.Interfaces;
using NetTopologySuite.Geometries;
using System.IO;
using System.Linq;
using Xunit;

namespace MobileFoodPermits.FileTests
{
    public class FoodPermitCollectionRepositoryTests
    {
        private readonly IFoodPermitCollectionRepository _permitCollectionRepository;
        public FoodPermitCollectionRepositoryTests()
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            var fileSettings = new FileSettings()
            {
                FileName = "TestData.csv",
                BasePath = projectDirectory
            };

            var sp = new ServiceCollection()
                .AddFoodPermitFileServices(fileSettings)
                .BuildServiceProvider();

            _permitCollectionRepository = sp.GetService<IFoodPermitCollectionRepository>();
        }
        [Fact]
        public void CanResolve()
        {
            Assert.NotNull(_permitCollectionRepository);
            Assert.IsType<FoodPermitCollectionRepository>(_permitCollectionRepository);
        }

        [Fact]
        public void GivenCorrectFile_Get_ShouldReturnsTwoResultsAndValidFirstPermit()
        {
            var collection = _permitCollectionRepository.GetFoodPermitCollection();

            Assert.Equal(2, collection.FoodPermits.Count());

            var first = collection.FoodPermits.First();
            var expectedCoordidate = new Coordinate(37.78844616, -122.3986412);
            Assert.Equal(1524388, first.LocationId);
            Assert.Equal(expectedCoordidate, first.Location);
        }
    }
}
