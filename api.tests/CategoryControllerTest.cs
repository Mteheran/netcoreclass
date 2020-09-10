using System;
using System.Linq;
using Xunit;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace api.tests
{
    public class CategoryControllerTest
    {
        
        [Fact]
        public void GetCategory()
        {
            //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var categories = categoryController.Get();

            //assert
            Assert.NotEmpty(categories.Value);
            Assert.Equal(3, categories.Value.Count());
            Assert.Equal("Category 1", categories.Value.ToList()[0].Description_Category);

        }

        [Fact]
        public void GetCategory_ById()
        {
            //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var categories = categoryController.Get();

            //assert
            Assert.NotEmpty(categories.Value);
            Assert.Equal(3, categories.Value.Count());
            Assert.Equal("Category 1", categories.Value.ToList()[0].Description_Category);

        }


        [Fact]
        public void GetCategory_ById_BadRequest()
        {
            //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var result = categoryController.Get("XXXXX");

            //assert
            Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public void GetCategory_ById_NotFound()
        {
            //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var result = categoryController.Get(Guid.Empty.ToString());

            //assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}