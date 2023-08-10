using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wati.Interview.Test.Model;
using Wati.Interview.Test.Service;

namespace Wati.Interview.Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        public IMathOperationService _mathOperationService;
        public ILogger _logger;

        public AddController(IMathOperationService mathOperationService, ILogger<AddController> logger)
        {
            _mathOperationService = mathOperationService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SumRequest request)
        {
            try
            {
                Sum sum = new Sum()
                {
                    Num1 = request.Num1,
                    Num2 = request.Num2
                };
                int result = await _mathOperationService.AddAsync(sum);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
