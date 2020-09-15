using System;
using System.Linq;
using Xunit;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;
using shared.Models;

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
            var category = categoryController.Get().Value.ToList()[0];

            //act
            var result = categoryController.Get(category.IdCategory.ToString()).Result as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Category 1", ((Category)result.Value).Description_Category);
            Assert.Equal(category.IdCategory,  ((Category)result.Value).IdCategory);

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

        [Fact]
        public void PostCategory()
        {
             //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var result = categoryController.Post("Category 1");
            var categoryList = categoryController.Get();

            //assert
            Assert.IsType<OkResult>(result.Result);
            Assert.Equal(4, categoryList.Value.Count());

        }

        [Fact]
        public void PostCategory_BadRequest()
        {
             //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var result = categoryController.Post(null);
            var categoryList = categoryController.Get();

            //assert
            Assert.IsType<BadRequestResult>(result.Result);
            Assert.Equal(3, categoryList.Value.Count());

        }

         [Fact]
        public void PutCategory()
        {
             //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);
            var category = categoryController.Get().Value.ToList()[0];

            //act
            var result = categoryController.Put(category.IdCategory.ToString(), "Category 11");
            var categoryList = categoryController.Get();

            //assert
            Assert.IsType<OkResult>(result.Result);
            Assert.Equal(3, categoryList.Value.Count());
            Assert.Equal("Category 11", categoryList.Value.ToList()[0].Description_Category);

        }

          [Fact]
        public void PutCategory_BadRequest()
        {
             //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var result = categoryController.Put(null, "Category 11");
            var categoryList = categoryController.Get();

            //assert
            Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public void PutCategory_NotFound()
        {
             //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);

            //act
            var result = categoryController.Put(Guid.Empty.ToString(), "Category 11");
            var categoryList = categoryController.Get();

            //assert
            Assert.IsType<NotFoundResult>(result.Result);

        }

        [Fact]
        public void DeleteCategory()
        {
             //arrange
            using var context  =   StoreContextInitializer.GetContext();
            var categoryController = new CategoryController(context);
            var category = categoryController.Get().Value.ToList()[0];

            //act
            var result = categoryController.Delete(category.IdCategory.ToString());
            var categoryList = categoryController.Get();

            //assert
            Assert.IsType<OkResult>(result.Result);
            Assert.Equal(2, categoryList.Value.Count());

        }
    }
}