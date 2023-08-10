using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using Wati.Interview.Test.Web.Models;

namespace Wati.Interview.Test.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AddNumbers([FromBody]SumRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("TestWebApi");
                client.BaseAddress = new Uri(_configuration.GetSection("ApiSetting:Url").Value);

                var data = new
                {
                    request.Num1,
                    request.Num2,
                };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await client.PostAsync("Add", content);

                if(httpResponse.IsSuccessStatusCode)
                {
                    string res = await httpResponse.Content.ReadAsStringAsync();

                    return Json(res);
                }
                else
                {
                    return Json(httpResponse);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Json(ex.ToString());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}