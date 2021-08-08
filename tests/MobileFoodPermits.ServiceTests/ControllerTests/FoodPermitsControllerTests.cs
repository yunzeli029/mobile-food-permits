using Microsoft.AspNetCore.Mvc;
using MobileFoodPermits.File.Services;
using MobileFoodPermits.File.Services.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using MobileFoodPermits.Service.Controllers;
using MobileFoodPermits.Service.Models;
using MobileFoodPermits.Service.Models.Filters;
using MobileFoodPermitsTests;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MobileFoodPermits.ServiceTests.ControllerTests
{
    public class FoodPermitsControllerTests
    {
        private readonly IFoodPermitCollectionRepository _permitCollectionRepository;

        private readonly FoodPermitsController _foodPermitsController;

        public FoodPermitsControllerTests()
        {
            _permitCollectionRepository = Substitute.For<IFoodPermitCollectionRepository>();

            _permitCollectionRepository.GetFoodPermitCollection().Returns(MockFixtures.MockFoodPermitCollection);

            var provider = new FoodPermitsProvider(_permitCollectionRepository);
            _foodPermitsController = new FoodPermitsController(provider);
        }

        [Fact]
        public void GetAll_ReturnsAOkResult_WithAllFoodPermits()
        {
            // Act
            var result = _foodPermitsController.GetAll();

            // Assert
            var objResult = Assert.IsAssignableFrom<OkObjectResult>(result);

            var permits = Assert.IsAssignableFrom<IEnumerable<FoodPermit>>(objResult.Value);

            Assert.Equal(6, permits.Count());
        }


        [Theory]
        [InlineData("APT", new[] { "Flavors of Africa" }, 1)]
        [InlineData("ST", new[] { "REQUESTED", "APPROVED" }, 3)]
        public void GivenValueFilterDto_GetFilteredResult_ReturnsAOkResult_WithFilteredFoodPermits(string shortName, string[] patterns, int expected)
        {
            var filter = new ItemValueFilterDto(shortName, patterns);
            var requestDto = new FilteredRequestDto(filter);

            // Act
            var result = _foodPermitsController.GetFilteredResult(requestDto);

            // Assert
            var objResult = Assert.IsAssignableFrom<OkObjectResult>(result);

            var permits = Assert.IsAssignableFrom<IEnumerable<FoodPermit>>(objResult.Value);

            Assert.Equal(expected, permits.Count());
        }

        [Fact]
        public void GivenGeoFilterDto_GetFilteredResult_ReturnsAOkResult_WithFilteredFoodPermits()
        {
            var coordinate = MockFixtures.MockCentre;
            var filter = new ItemGeoFilterDto(coordinate.X, coordinate.Y, 50);
            var requestDto = new FilteredRequestDto(filter);

            // Act
            var result = _foodPermitsController.GetFilteredResult(requestDto);

            // Assert
            var objResult = Assert.IsAssignableFrom<OkObjectResult>(result);

            var permits = Assert.IsAssignableFrom<IEnumerable<FoodPermit>>(objResult.Value);

            Assert.Equal(3, permits.Count());
        }


    }
}
