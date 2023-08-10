using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Wati.Interview.Test.Controllers;
using Wati.Interview.Test.Model;
using Wati.Interview.Test.Service;

namespace Wati.Interview.Test.unitTest
{
    public class SumOperationTest
    {
        private readonly Mock<IMathOperationService> MathOperationService;
        private readonly Mock<ILogger<AddController>> Logger;
        
        public SumOperationTest()
        {
            MathOperationService = new Mock<IMathOperationService>();
            Logger = new Mock<ILogger<AddController>>();
        }

        [Fact]
        public async void SumMethod()
        {
            int Num1 = 10, Num2 = 20;
            int sumofNum = Num1 + Num2;

            Sum sum = new Sum()
            {
                Num1 = Num1,
                Num2 = Num2
            };

            MathOperationService.Setup(x => x.AddAsync(It.IsAny<Sum>())).ReturnsAsync(sumofNum);

            var addControllerTest = new AddController(MathOperationService.Object, Logger.Object);

            SumRequest request = new SumRequest()
            {
                Num1 = Num1,
                Num2 = Num2
            };

            var postResult = await addControllerTest.Post(request) as OkObjectResult;


            Assert.Equal(200, postResult.StatusCode);
            Assert.Equal(sumofNum, (int)postResult.Value);

        }
    }
}