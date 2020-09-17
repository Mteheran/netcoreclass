using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;

namespace api.tests
{
    public class WeatherForecastTest
    {
        [Fact]
        public void GetWeatherForecast()
        {
            //Given
            //using var loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder
            //        .AddFilter("Microsoft", LogLevel.Warning)
            //        .AddFilter("System", LogLevel.Warning)
            //        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
            //        .AddConsole();
            //});
            //var logger = loggerFactory.CreateLogger<WeatherForecastController>();
            var moqLogger = Mock.Of<ILogger<WeatherForecastController>>();

            var controller  = new WeatherForecastController(moqLogger);
            
            //When
            var result = controller.Get();
            
            //Then
            Assert.NotEmpty(result);
            Assert.InRange<int>(result.Count(), 1, 5);

        }
       
    }
}