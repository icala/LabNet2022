using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Demo.EF.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Lab.Demo.EF.Logic;
using Lab.Demo.EF.Entities;
using System.Web.Http;
using System.Web.Http.Results;
using Lab.Demo.EF.Entities.DTOs;

namespace Lab.Demo.EF.API.Controllers.Tests
{
    [TestClass()]
    public class CategoriesControllerTests
    {
        [TestMethod()]
        public async Task GetReturnsCategoryWithSameId()
        {
            // Arrange
            var mockCategoriesLogic = new Mock<CategoriesLogic>();
            mockCategoriesLogic.Setup(x => x.GetCategoryByIdAsync(11))
                .ReturnsAsync(new Categories { CategoryID = 11 });

            var controller = new CategoriesController(mockCategoriesLogic.Object);

            // Act
            IHttpActionResult actionResult = await controller.Get(11);
            var contentResult = actionResult as OkNegotiatedContentResult<CategoriesDTO>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(11, contentResult.Content.CategoryID);
        }

        [TestMethod()]
        public async Task PatchTest_DifiereId_retornaBadRequest()
        {
            // Arrange
            var controller = new CategoriesController(null);
            var category11Dto = new CategoriesDTO() { CategoryID = 11 };
            // Act
            IHttpActionResult actionResult = await controller.Patch(12,category11Dto );

            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
    }
}