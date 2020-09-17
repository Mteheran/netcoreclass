using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;
using shared.Models;
using AutoFixture;

namespace api.tests
{
    public class UserTypeControllerTest
    {
        public Fixture fixture {get;set;}

        public UserTypeControllerTest()
        {
            fixture = new Fixture();
        }


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
            var userType = userTypeController.Get().Value.ToList()[0];
            
            var userTypes = userTypeController.Get(userType.IdUser_Type.ToString());


            //assert        
            Assert.Equal("Tipo Usuario 1", userTypes.Value.Description_Type);

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
        public void GetUserType_ById_NotFound()
        {
            using var context  =   StoreContextInitializer.GetContext();
            var userTypeController = new UserTypeController(context);
            var result = userTypeController.Get(Guid.Empty.ToString());
            Assert.IsType<NotFoundResult>(result.Result);

        }


        [Fact]
        public void PostUserType()
        {
            using var context  =   StoreContextInitializer.GetContext();
            var userTypeController = new UserTypeController(context);        
            var userTypeAuto = fixture.Build<UserType>().Without(p=> p.Users).With(p=> p.Description_Type).Create();

            var result = userTypeController.Post(userTypeAuto);

            Assert.IsType<OkResult>(result.Result);

        }
    }
}