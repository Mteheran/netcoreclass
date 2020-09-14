using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace api.tests
{
    public class UserTypeControllerTest
    {
        [Fact]
        public void GetUserTypes()
        {
            using var context  =   StoreContextInitializer.GetContext();
            var userTypeController = new UserTypeController(context);
            var userTypes = userTypeController.Get();
            Assert.NotEmpty(userTypes.Value);
            Assert.Equal(3, userTypes.Value.Count());
            Assert.Equal("Tipo Usuario 2", userTypes.Value.ToList()[1].Description_Type);

        } 

        [Fact]
        public void GetUserType_ById()
        {
            using var context  =   StoreContextInitializer.GetContext();
            var userTypeController = new UserTypeController(context);
            var userTypes = userTypeController.Get();


            //assert
            Assert.NotEmpty(userTypes.Value);
            Assert.Equal(3, userTypes.Value.Count());
            Assert.Equal("Tipo Usuario 1", userTypes.Value.ToList()[0].Description_Type);

        }


        [Fact]
        public void GetUserType_BadRequest()
        {
           
            using var context  =   StoreContextInitializer.GetContext();
            var userTypeController = new UserTypeController(context);
             var result = userTypeController.Get("ZZZZZZZZ");
            Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public void GetCategory_ById_NotFound()
        {
            using var context  =   StoreContextInitializer.GetContext();
            var userTypeController = new UserTypeController(context);
            var result = userTypeController.Get(Guid.Empty.ToString());
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}