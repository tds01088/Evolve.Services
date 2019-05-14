using Evolve.TollFeeCalculator.Config;
using Evolve.TollFeeCalculator.Interfaces;
using Evolve.TollFeeCalculator.Models;
using Evolve.TollFeeCalculator.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace Evolve.TollFeeCalculator.Test
{
    public class GeneralUnitTest
    {
        private IConfiguration _configuration { get; set; }
        public GeneralUnitTest()
        {
            _configuration = new ConfigurationBuilder()
              .AddJsonFile("client-secrets.json")
              .Build();
            IAppConfiguration appConfiguration = new AppConfiguration(_configuration);
        }


        /// <summary>
        ///  Facts are tests which are always true. They test invariant conditions.
        ///  test Configuration
        /// </summary>
        [Fact]
        public void Test_Configuration()
        {
            Assert.Equal(4, Add(2, 2));

            //var clientId = config["AUTH0_CLIENT_ID..."];
            //Assert.Throws<ArgumentException>(() =>  clientId);              
            //   Assert.Throws<ArgumentException>(() => Globals.AppConfiguration.CostParameters.ExtraCostFactor);
            Assert.Equal(1, Globals.AppConfiguration.CostParameters.ExtraCostFactor);
        }


        [Fact]
        public void Test_TollFeeCalculatorService()
        {
            /* var mock = new Mock<ITollFeeCalculatorService>();//(MockBehavior.Strict);           
             mock.Setup(foo => foo.GetTollFee(new Car(), new DateTime[]{ })).Returns(8);
             //var CostTollFee =mock.Object*/
            var CostTollFee = new TollFeeCalculatorService().GetTollFee(new Car(),new DateTime[] { new DateTime(2019, 05, 8, 10, 30, 0),
                                              new DateTime(2019, 05, 9, 10, 30, 0),
                                              new DateTime(2019, 05, 9, 10, 56, 0) });

            Assert.Equal(8, CostTollFee);

        }
        /// <summary>
        /// Theories are tests which are only true for a particular set of data.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="expectedFullName"></param>
        [Theory]
        [InlineData(" Mary", "  Jane  ", "Mary Jane")]
        [InlineData(" Bob", "Marley", "Bob Marley")]
        [InlineData(" Joe Hanson", " Lee   ", "Joe Hanson Lee")]
        [InlineData(" Joe Hanson", " Lee   ", " Joe Hanson")]
        public void GetFullName_ValidInputs_ReturnsCorrectResult_Example2(string firstName,
                                                  string lastName, string expectedFullName)
        {
            //string fullNameResult = UserUtil.GetFullName(firstName, lastName);
            Assert.Equal(expectedFullName, firstName);
        }


        /// <summary>
        /// Theories are tests which are only true for a particular set of data.
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory_test(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
