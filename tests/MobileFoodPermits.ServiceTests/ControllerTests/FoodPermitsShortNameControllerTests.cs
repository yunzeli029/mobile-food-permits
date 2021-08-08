using Microsoft.AspNetCore.Mvc;
using MobileFoodPermits.Models.FoodPermitInfo;
using MobileFoodPermits.Service.Controllers;
using System.Collections.Generic;
using Xunit;

namespace MobileFoodPermits.ServiceTests.ControllerTests
{
    public class FoodPermitsShortNameControllerTests
    {
        [Fact]
        public void Get_ReturnsAOkResult_WithAListOfShortNames()
        {
            // Arrange
            var controller = new FoodPermitsShortNameController();

            // Act
            var result = controller.Get();

            // Assert
            var expected = ShortNameMappings.ShortNameToPropertyMapping.Keys;
            var objResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var shortNames = Assert.IsAssignableFrom<IEnumerable<string>>(objResult.Value);

            Assert.Equal(expected, shortNames);
        }
    }
}
