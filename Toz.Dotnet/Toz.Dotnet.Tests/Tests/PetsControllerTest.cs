using Xunit;
using Toz.Dotnet.Controllers;
using Toz.Dotnet.Core.Services;
using Toz.Dotnet.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Toz.Dotnet.Core.Interfaces;
using Toz.Dotnet.Tests.Helpers;

namespace Toz.Dotnet.Tests.Tests {
    public class PetsControllerTest
    {
        private IPetsManagementService _petsManagementService;
        public PetsControllerTest()
        {
            _petsManagementService = ServiceProvider.Instance.Resolve<IPetsManagementService>();
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfPets()
        {
            var controller = new PetsController(_petsManagementService);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
             var model = Assert.IsAssignableFrom<List<Pet>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count);
        }
    }
}