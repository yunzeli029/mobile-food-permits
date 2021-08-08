using Microsoft.Extensions.DependencyInjection;
using MobileFoodPermits.File.DependencyInjection;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.File.Services;
using MobileFoodPermits.File.Services.Interfaces;
using System.IO;
using System.Linq;
using Xunit;

namespace MobileFoodPermits.FileTests
{
    public class PermitCollectionRepositoryTests
    {
        private readonly IPermitCollectionRepository _permitCollectionRepository;
        public PermitCollectionRepositoryTests()
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            var fileSettings = new FileSettings()
            {
                FileName = "TestData.csv",
                BasePath = projectDirectory
            };

            var sp = new ServiceCollection()
                .AddFilePermits(fileSettings)
                .BuildServiceProvider();

            _permitCollectionRepository = sp.GetService<IPermitCollectionRepository>();
        }
        [Fact]
        public void CanResolve()
        {
            Assert.NotNull(_permitCollectionRepository);
            Assert.IsType<PermitCollectionRepository>(_permitCollectionRepository);
        }

        [Fact]
        public void GivenCorrectFile_Get_ShouldReturnsTwoResultsAndValidFirstPermit()
        {
            var collection = _permitCollectionRepository.Get();

            Assert.Equal(2, collection.PermitInfos.Count());

            var first = collection.PermitInfos.First();

            Assert.Equal(1524388, first.LocationId);
        }
    }
}
