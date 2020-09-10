using System;
using Xunit;

namespace api.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var number1= 1;
            var number2 = 2;

            //Act
            var result = number1 + number2;

            //Assert
            Assert.Equal(3, result);
        }
    }
}
